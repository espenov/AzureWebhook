using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.WebHooks;
using System.Threading.Tasks;

namespace AzureWebhook.WebHooks
{
    public class KuduWebHookHandler : WebHookHandler
    {
        public KuduWebHookHandler()
        {
            Receiver = "kudu";
        }

        public override Task ExecuteAsync(string generator, WebHookHandlerContext context)
        {
            // Convert to POCO type
            KuduNotification notification = context.GetDataOrDefault<KuduNotification>();

            // Get the notification message
            string message = notification.Message;

            // Get the notification author
            string author = notification.Author;

            return Task.FromResult(true);
        }
    }
}