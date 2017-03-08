using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.WebHooks;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Net.Http;

namespace AzureWebhook.WebHooks
{
    public class SlackWebHookHandler : WebHookHandler
    {
       public override Task ExecuteAsync(string generator, WebHookHandlerContext context)
       {
           NameValueCollection nvc;
           if (context.TryGetData<NameValueCollection>(out nvc))
           {
               string question = nvc["subtext"];
               string msg = string.Format("The answer to '{0}' is '{1}'.", question, "Often");
               SlackResponse reply = new SlackResponse(msg);
               context.Response = context.Request.CreateResponse(reply);
           }
           return Task.FromResult(true);
       }
   }
}