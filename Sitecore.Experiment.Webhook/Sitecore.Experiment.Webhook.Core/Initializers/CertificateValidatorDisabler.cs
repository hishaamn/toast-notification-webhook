using Sitecore.Pipelines;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Sitecore.Experiment.Webhook.Core.Initializers
{
    public class CertificateValidatorDisabler
    {
        public void Process(PipelineArgs args)
        {
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateCertificate);
        }

        static bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
    }
}
