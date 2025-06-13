using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SMTPsendEmail.Services
{
    public class TwilioService
    {
        private readonly IConfiguration _config;
        public TwilioService(IConfiguration config)
        {
            _config = config;
        }
        public void SendSMS(string toPhone, string message)
        {
            var accountSid = _config["Twilio:AccountSID"];
            var authToken = _config["Twilio:AuthToken"];
            var fromPhone = _config["Twilio:FromPhone"];
            TwilioClient.Init(accountSid, authToken);
            var messageResource = MessageResource.Create(
                to: new PhoneNumber(toPhone),
                from: new PhoneNumber(fromPhone),
                body: message
            );
        }

        
    }
}
