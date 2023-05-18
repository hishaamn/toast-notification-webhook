using Newtonsoft.Json;
using Sitecore.Experiment.Webhook.Core.Models;
using Sitecore.Experiment.Webhook.Core.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sitecore.Experiment.Webhook.Controllers
{
    public class WebhookController : ApiController
    {
        // GET: api/Webhook
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public IHttpActionResult TestGet(dynamic itemNotification)
        {
            NotificationProcessor.Process(itemNotification);

            return Ok();
        }
    }
}
