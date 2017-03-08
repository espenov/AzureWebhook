using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.WebHooks;
using System.Threading.Tasks;


namespace AzureWebhook.WebHooks
{
    public class AzureAlertWebHookHandler : WebHookHandler
    {
        public AzureAlertWebHookHandler()
        {
            Receiver = "azurealert";
        }

        public override Task ExecuteAsync(string generator, WebHookHandlerContext context)
        {
            // Convert to POCO type
            AzureAlertNotification notification = context.GetDataOrDefault<AzureAlertNotification>();

            // Get the notification status
            string status = notification.Status;

            // Get the notification name
            string name = notification.Context.Name;

            // Get the name of the metric that caused the event
            string author = notification.Context.Condition.MetricName;

            //context.Response = context.Request.

            return Task.FromResult(true);
        }
    }
}