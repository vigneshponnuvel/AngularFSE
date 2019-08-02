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
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private IFeedbackDataProvider feedbackDataProvider;

        public FeedbackController(IFeedbackDataProvider feedbackDataProvider)
        {
            this.feedbackDataProvider = feedbackDataProvider;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task Post([FromBody]TTtrnFeedback feedback)
        {
            await this.feedbackDataProvider.AddFeedback(feedback);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<TTtrnFeedback> Get(int id)
        {
            return await this.feedbackDataProvider.GetFeedback(id);
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<TTtrnFeedback>> Get()
        {
            return await this.feedbackDataProvider.GetAllFeedback();
        }
    }
}