﻿using System.Web;
using System.Web.Mvc;

namespace Sitecore.Experiment.Webhook
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
