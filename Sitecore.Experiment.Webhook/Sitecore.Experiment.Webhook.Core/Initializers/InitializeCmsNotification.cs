using Sitecore.Experiment.Webhook.Core.Managers;
using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Experiment.Webhook.Core.Initializers
{
    public class InitializeCmsNotification
    {
        public void Process(PipelineArgs args) => CmsNotificationManager.Initialize();
    }
}
