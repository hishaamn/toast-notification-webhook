using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Events;
using Sitecore.SecurityModel;
using Sitecore.Sites;
using System;
using System.Collections.Generic;

namespace Sitecore.Experiment.Webhook.Core.Managers
{
    public class CmsNotificationManager
    {
        private static Dictionary<string, string> EventMessages;

        public static void Initialize()
        {
            EventMessages = new Dictionary<string, string>();

            Database database = Factory.GetDatabase("master");

            foreach (ID selectId in database.DataManager.DataSource.SelectIDs(null, WebhookIDs.WebhookHandlerTemplate))
            {
                Item obj;

                using (new SecurityDisabler())
                {
                    obj = database.GetItem(selectId);
                }

                if (!obj.Name.Equals("__Standard Values", StringComparison.OrdinalIgnoreCase) && new CheckboxField(obj.Fields[WebhookFieldIDs.Enabled]).Checked && new CheckboxField(obj.Fields["Is Notification Enable"]).Checked)
                {
                    SubscribeEvents(GetIdsFromString(obj.Fields[WebhookFieldIDs.Events].Value), obj);
                }
            }
        }

        private static ICollection<string> GetIdsFromString(string value) => value.Split(new char[1]
        {
          '|'
        }, StringSplitOptions.RemoveEmptyEntries);

        private static void SubscribeEvents(ICollection<string> ids, Item item)
        {
            var action = new Action<string, EventHandler>(Event.Subscribe);

            foreach (string id in ids)
            {
                Database database = item.Database;
                
                Item obj;
                
                using (new SecurityDisabler())
                {
                    obj = database.GetItem(id);
                }

                if (obj == null)
                {
                    return;
                }
                else
                {
                    var eventName = obj[WebhookFieldIDs.EventName];

                    var eventMessage = obj["Event Message"];

                    if (!string.IsNullOrEmpty(eventName))
                    {
                        action(eventName, new EventHandler(CmsNotifier));

                        if (string.IsNullOrEmpty(eventMessage))
                        {
                            eventMessage = "[Default] :: Event has been processed";
                        }

                        EventMessages.Add(eventName, eventMessage);
                    }
                }
            }
        }

        private static void CmsNotifier(object sender, EventArgs args)
        {
            var shellSite = SiteContext.GetSite("shell");

            using(new SiteContextSwitcher(shellSite))
            {
                var parameters = args as SitecoreEventArgs;

                var message = EventMessages[parameters.EventName];

                var script = $"toastr.info('{message}')";

                var page = Context.Page;

                try
                {
                    if (Context.ClientPage != null)
                    {
                        var clientPageTypeName = Context.ClientPage.GetType().Name;

                        if (clientPageTypeName.Equals("sitecore_shell_applications_content_manager_default_aspx") || Context.ClientPage.ClientQueryString.Contains("Installer.InstallPackage"))
                        {
                            Context.ClientPage.ClientResponse.Eval(script);
                        }
                    }                    
                }
                catch(Exception ex)
                {
                    Log.Error($"[CMSNOTIFICATION] :: An error occurred in {nameof(CmsNotificationManager)}.\n\rMessage: {ex.Message}.\n\rStackTrace: {ex.StackTrace}.\n\rInnerException: {ex.InnerException}", nameof(CmsNotificationManager));
                }                
            }            
        }
    }
}
