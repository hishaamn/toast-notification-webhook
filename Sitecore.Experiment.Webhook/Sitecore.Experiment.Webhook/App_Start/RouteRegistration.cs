using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Sitecore.Experiment.Webhook.App_start
{
    public class RouteRegistration
    {
        public virtual void Process(PipelineArgs args)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        public class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                config.Routes.MapHttpRoute(
                    "CmsNotifier",
                    "{api}/notification/read",
                    new { controller = "Webhook", action = "TestGet" }
                );
            }
        }
    }
}
