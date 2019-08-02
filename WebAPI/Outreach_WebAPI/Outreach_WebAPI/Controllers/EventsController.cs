using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Outreach_WebAPI.Models;
using Outreach_WebAPI.DataProvider;

namespace Outreach_WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private IEventsDataProvider eventsDataProvider;

        public EventsController(IEventsDataProvider eventsDataProvider)
        {
            this.eventsDataProvider = eventsDataProvider;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<TEventSummary>> Get()
        {
            return await this.eventsDataProvider.GetEvents();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<TEventSummary> Get(string id)
        {
            return await this.eventsDataProvider.GetEvent(id);
        }

        [HttpGet("{eventID}/{associateID}/{feedBackType}")]
        [AllowAnonymous]
        public async Task<TEventInformation> Get(string eventID, int associateID, int feedbackType)
        {
            return await this.eventsDataProvider.GetEventFromIDAndAssoID(eventID, associateID, feedbackType);
        }
    }
}