using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TwilioMicro.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class SendMessageController : Controller
    {
        private readonly IEnvironmentConfiguration environmentConfiguration;
        public SendMessageController(IEnvironmentConfiguration environmentConfiguration)
        {
            this.environmentConfiguration = environmentConfiguration;

        }
        [HttpPost]
        public void Post([FromBody]CatMessage value)
        {
            string accountSid = environmentConfiguration.SID;
            string authToken = environmentConfiguration.AUTH;
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(environmentConfiguration.D_NUMBER);
            var message = MessageResource.Create(
                to,
                from: new PhoneNumber(environmentConfiguration.O_NUMBER),
                body: $"You have a new message from {value.Name}. {value.Message}");
        }
    }

    public class CatMessage
    {
        public string Name;
        public string Message;
    }
}