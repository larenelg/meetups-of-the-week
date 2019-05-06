using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DataDrivenDiversity.Api;
using DataDrivenDiversity.Api.Models;
using DataDrivenDiversity.Models.Domain;
using DataDrivenDiversity.Models.View;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DataDrivenDiversity.Controllers.Statistics
{
    public class StatisticsController : Controller
    {
        private readonly string[] PRONOUNS =  new string[]{ "they", "her", "him", "she", "he", "his", "them" };
        private readonly IMeetupApi _Api;
        private readonly INerApi _NerApi;

        public StatisticsController(IMeetupApi _api, INerApi _iNerApi)
        {
            _Api = _api;
            _NerApi = _iNerApi;
        }

        [HttpGet("speaker-ratio/{days}")]
        public IActionResult SpeakerRatio(int days)
        {
            // get all past events for tech in brisbane in the last week
            var query = new GroupsQueryParams {
                    Country = "Australia",
                    Lat = "-27.470125",
                    Lon = "153.021072",
                    Radius = 10,
                    CategoryId = 34
                };

            var groups = _Api.SearchGroups(query).Result.Results;

            var allEventsLastWeek = new List<List<MeetupEvent>>();

            foreach (var group in groups)
            {
                var events = _Api.GetPastEvents(group.UrlName).Result.Results;
                
                var eventsLastWeek = events.Where(e => e.Time > DateTime.Now.AddDays(-(days)));

                var eventsLastWeekWithSpeakers = eventsLastWeek.Select(ev => {
                            ev.SpeakerData = ExtractSpeakers(group.UrlName, ev);
                            return ev;
                        });

                allEventsLastWeek.Add(
                        eventsLastWeekWithSpeakers.ToList()
                    );
            }

            var model = new SpeakerRatioViewModel {
                Events = allEventsLastWeek
            };

            return View(model);
        }

        private SpeakerData ExtractSpeakers(string groupUrl, MeetupEvent ev)
        {
            if (ev == null || ev.Description == null)
            {
                //
            }
            else
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(ev.Description);

                var plainTextDescription = ev.Name != null ? ev.Name : "";
                foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//text()"))
                {
                    plainTextDescription += $" {node.InnerText}";
                }
                plainTextDescription = Regex.Replace(plainTextDescription, @"[^\u0020-\u007E]", string.Empty);
                
                try
                {
                    /* using Python library */
                    // var pronouns = _StatsApi.ExtractSpeaker(plainTextDescription).Result.Pronouns;
                    /* using Stanford lib */
                    var results = _NerApi.Analyse(plainTextDescription).Result;
                    var people = results.Sentences
                            .SelectMany(i => i.Entitymentions)
                            .Where(e => e.Ner == "PERSON")
                            .Select(e => e.Text)
                            .Distinct()
                            .ToArray();

                    var pronouns = people.Where(text => PRONOUNS.Contains(text.ToLowerInvariant())).ToArray();
                    var speakers = people.Where(name => !PRONOUNS.Contains(name.ToLowerInvariant())).ToArray();

                    Log.Information("NLP: Speakers found for group {GroupName} event id {EventId}, {@SpeakerData}", groupUrl, ev.Id, people);
                    
                    var speakerData = new Models.Domain.SpeakerData {
                        Pronouns = pronouns,
                        Names = speakers
                    };

                    return speakerData;

                }
                catch (Exception ex)
                {
                    // something went wrong, but keep going
                    Log.Error(ex, "NLP: Error extracting speakers");
                    return null;
                }
            }
            return null;
        }
    }
}