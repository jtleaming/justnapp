using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("{phoneNumber}/{gifcode}")]
        public void Get(string phoneNumber, string gifcode)
        {
            var gifUri = $"https://media2.giphy.com/media/{gifcode}/200_d.gif";
            var accountSid = environmentConfiguration.SID;
            var authToken = environmentConfiguration.AUTH;  

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                to: new PhoneNumber("+"+phoneNumber),
                from: new PhoneNumber(environmentConfiguration.O_NUMBER),
                mediaUrl: new List<Uri> { new Uri(gifUri)});
        }
    }

    public class GifMessage
    {
    }

    public class CatMessage
    {
        public string Name;
        public string Message;
    }
}