using System;

namespace Sitecore.Experiment.Webhook.Core.Models
{
    public class NotifierArgs : EventArgs
    {
        public string EventName { get; set; }
    }
}
