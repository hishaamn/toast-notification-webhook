using System;
using System.Web.UI;

namespace Sitecore.Experiment.Webhook.Core.Managers
{
    public class ShellDefaultPageExtension : Sitecore.Shell.DefaultPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            var control = this.Controls[0];

            var page = control.Page;

            if (page.ClientQueryString.Equals("xmlcontrol=Installer.InstallPackage"))
            {
                page.Header.Controls.Add(new LiteralControl("<script type='text/JavaScript' src='/sitecore/shell/Controls/Lib/jQuery/jquery-1.12.4.min.js'></script>"));
                page.Header.Controls.Add(new LiteralControl("<script type='text/javascript' language='javascript' src='/sitecore/toastr/toastr.js'></script>"));
                page.Header.Controls.Add(new LiteralControl("<link href='/sitecore/toastr/toastr.css' rel='stylesheet'/>"));
            }
        }
    }
}
