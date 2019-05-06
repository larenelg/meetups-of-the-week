using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DataDrivenDiversity.Api;
using DataDrivenDiversity.Infrastructure;
using DataDrivenDiversity.Models.View;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DataDrivenDiversity.Controllers.Groups
{
    [Route("[controller]")]
    public class GroupController : Controller
    {
        private readonly string[] PRONOUNS =  new string[]{ "they", "her", "him", "she", "he", "his", "them" };
        private readonly IMeetupApi _MeetupApi;
        private readonly SpeakerDataRepository _Repo;
        private readonly IStatsApi _StatsApi;
        private readonly INerApi _NerApi;

        public GroupController(IMeetupApi _meetupApi, IStatsApi _statsApi, INerApi _nerApi)
        {
            _StatsApi = _statsApi;
            _NerApi = _nerApi;
            _MeetupApi = _meetupApi;
            _Repo = new SpeakerDataRepository();
        }

        [Route("{urlname}")]
        public IActionResult Index(string urlname)
        {
            var group = _MeetupApi.GetGroup(urlname).Result;
            var model = new GroupViewModel
            {
                Name = group.Name,
                Url = group.Link,
                Members = group.Members,
                Description = group.Description,
                Created = group.Created,
                Organiser = group.Organizer.Name
            };

            return View(model);
        }

        [Route("{urlname}/events")]
        public IActionResult Events(string urlname)
        {
            var groupName = _MeetupApi.GetGroup(urlname).Result.Name;
            var events = _MeetupApi.GetPastEvents(urlname).Result.Results;

            var model = new EventsViewModel
            {
                GroupName = groupName,
                GroupUrlName = urlname,
                Events = events
            };

            return View(model);
        }
            
        [Route("{urlname}/event/{id}")]
        public IActionResult Event(string urlname, string id)
        {
            var ev = _MeetupApi.GetPastEvents(urlname).Result.Results.Where(e => e.Id == id).FirstOrDefault();

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
                    var speakers = people.Where(name => name.Contains(" ")).ToArray();

                    Log.Information("NLP: Speakers found for group {GroupName} event id {EventId}, {@SpeakerData}", urlname, id, people);
                    
                    var speakerData = new Models.Domain.SpeakerData {
                        Pronouns = pronouns,
                        Names = speakers
                    };

                    ev.SpeakerData = speakerData;

                    // _Repo.SaveSpeakerData(id, speakerData);
                }
                catch (Exception ex)
                {
                    // something went wrong, but keep going
                    Log.Error(ex, "NLP: Error extracting speakers");
                    ev.SpeakerData = null;
                }
            };

            ev.Time = ev.Time.ToLocalTime();

            var model = new EventViewModel {
                GroupUrlName = urlname,
                Event = ev
            };
            return View(model);
        }
    }
}