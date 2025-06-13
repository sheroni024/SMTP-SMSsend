using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Twilio.Types;
using Twilio;
using SMTPsendEmail.Models;
using Twilio.Rest.Api.V2010.Account;
using SMTPsendEmail.Services;

namespace SMTPsendEmail.Controllers
{
    public class SMSController : Controller
    {
        private readonly TwilioService _twilioService;

        public SMSController(TwilioService twilioService)
        {
            _twilioService = twilioService;
        }


        
        public IActionResult Send()
        {
            _twilioService.SendSMS("+917383357061", "You have successfully registered to Twilio !");
            return Content("SMS Sent");
        }
    }
}
