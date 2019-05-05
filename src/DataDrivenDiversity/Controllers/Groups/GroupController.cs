using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DataDrivenDiversity.Api;
using DataDrivenDiversity.Models.View;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace DataDrivenDiversity.Controllers.Groups
{
    [Route("[controller]")]
    public class GroupController : Controller
    {
        private readonly IMeetupApi _MeetupApi;
        private readonly IStatsApi _StatsApi;

        public GroupController(IMeetupApi _meetupApi, IStatsApi _statsApi)
        {
            _StatsApi = _statsApi;
            _MeetupApi = _meetupApi;
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
            var events = _MeetupApi.GetPastEvents(urlname).Result.Results;

            foreach (var ev in events)
            {
                // if (ev.Description == null)
                // {
                //     ev.SpeakerData = new Models.Domain.SpeakerData();
                // }
                // else
                // {
                //     HtmlDocument doc = new HtmlDocument();
                //     doc.LoadHtml(ev.Description);

                //     var plainTextDescription = ev.Name != null ? ev.Name : "";
                //     foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//text()"))
                //     {
                //         plainTextDescription += $" {node.InnerText}";
                //     }
                //     plainTextDescription = Regex.Replace(plainTextDescription, @"[^\u0020-\u007E]", string.Empty);

                //     try
                //     {
                //         ev.SpeakerData = _StatsApi.ExtractSpeaker(plainTextDescription).Result;
                //     }
                //     catch (Exception ex)
                //     {
                //         // something went wrong, but keep going
                //         ev.SpeakerData = new Models.Domain.SpeakerData();
                //     }
                // };
            }


            var model = new EventsViewModel
            {
                GroupUrlName = urlname,
                Events = events
            };

            return View(model);
        }
            
        [Route("{urlname}/event/{id}")]
        public IActionResult Event(string urlname, string id)
        {
            
            var ev = _MeetupApi.GetPastEvents(urlname).Result.Results.Where(e => e.Id == id).FirstOrDefault();


            if (ev.Description == null)
            {
                ev.SpeakerData = new Models.Domain.SpeakerData();
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


                /* using Python library */
                // try
                // {
                //     ev.SpeakerData = _StatsApi.ExtractSpeaker(plainTextDescription).Result;
                // }
                // catch (Exception ex)
                // {
                //     // something went wrong, but keep going
                //     ev.SpeakerData = new Models.Domain.SpeakerData();
                // }

                /* using Stanford NLP NER */
                // ev.SpeakerData = new Models.Domain.SpeakerData {
                //     Names = (new StanfordNameEntityRecognizer()).ExtractNames(plainTextDescription),
                //     Pronouns = new List<string>()
                // };
                ev.SpeakerData = new Models.Domain.SpeakerData();
            };

            var model = new EventViewModel {
                GroupUrlName = urlname,
                Event = ev
            };
            return View(model);
        }
    }
}