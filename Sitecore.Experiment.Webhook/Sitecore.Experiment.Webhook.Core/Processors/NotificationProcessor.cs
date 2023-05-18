using Newtonsoft.Json;
using Sitecore.Events;
using Sitecore.Experiment.Webhook.Core.Models;
using Sitecore.Sites;
using Sitecore.Web.UI.Sheer;

namespace Sitecore.Experiment.Webhook.Core.Processors
{
    public class NotificationProcessor
    {
        public static void Process(dynamic itemNotification)
        {
            var shellSite = SiteContext.GetSite("shell");

            using (new SiteContextSwitcher(shellSite))
            {
                WebhookModel result = JsonConvert.DeserializeObject<WebhookModel>(itemNotification.ToString());

                var x = result;

                var notifier = new NotifierArgs
                {
                    EventName = result.EventName
                };

                //Sitecore.Context.ClientPage.ClientResponse.Eval("alert('test')");
                Event.RaiseEvent("cms:notify", notifier);
                //SheerResponse.Eval("alert('test')");
            };            
        }
    }
}
