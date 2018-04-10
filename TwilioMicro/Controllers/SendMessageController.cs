using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<SendMessageController> logger;
        public SendMessageController(IEnvironmentConfiguration environmentConfiguration, ILogger<SendMessageController> logger)
        {
            this.logger = logger;
            this.environmentConfiguration = environmentConfiguration;

        }
        [HttpPost]
        public IActionResult Post([FromBody]CatMessage value)
        {
            try
            {
                string accountSid  = environmentConfiguration.SID;
                string authToken = environmentConfiguration.AUTH;
                TwilioClient.Init(accountSid, authToken);

                var to = new PhoneNumber(environmentConfiguration.D_NUMBER);
                var message = MessageResource.Create(
                    to,
                    from: new PhoneNumber(environmentConfiguration.O_NUMBER),
                    body: $"You have a new message from {value.Name}. {value.Message}");
                return Ok("Success!");
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{phoneNumber}/{gifcode}")]
        public IActionResult SendGif(string phoneNumber, string gifcode)
        {
            logger.LogInformation("Message recieved.");
            Thread.Sleep(3000);
            try
            {
                var gifUri = $"https://media2.giphy.com/media/{gifcode}/200_d.gif";
                var accountSid = environmentConfiguration.SID;
                var authToken = environmentConfiguration.AUTH;

                TwilioClient.Init(accountSid, authToken);

                logger.LogInformation($"Sending {gifUri}");
                var message = MessageResource.Create(
                    to: new PhoneNumber("+" + phoneNumber),
                    from: new PhoneNumber(environmentConfiguration.O_NUMBER),
                    mediaUrl: new List<Uri> { new Uri(gifUri) });
                return Ok("success");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }

    public class CatMessage
    {
        public string Name;
        public string Message;
    }
}