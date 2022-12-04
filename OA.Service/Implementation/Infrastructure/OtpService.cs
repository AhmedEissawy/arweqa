using Microsoft.Extensions.Options;
using OA.Data;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Verify.V2.Service;

namespace OA.Service.Implementation.Infrastructure
{
    public class OtpService : IOtpService
    {
        private readonly TwilioConfiguration _twilioConfiguration;

        public OtpService(IOptions<TwilioConfiguration> twilioConfiguration)
        {
            _twilioConfiguration = twilioConfiguration.Value;
            TwilioClient.Init(_twilioConfiguration.AccountSid, _twilioConfiguration.AuthToken);
        }
        public async Task<bool> SendConfirmationCode(string phone)
        {
            try
            {
                if (!phone.StartsWith("+"))
                    phone = $"+{phone}";
                

                var response = await VerificationResource.CreateAsync
                    (
                    to:phone,
                    channel:"sms",
                    pathServiceSid:_twilioConfiguration.PathServiceSid
                    );
                
                return true;
               
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> ValidateConfirmationCode(string phone,string code)
        {
            try

            {
                if (!phone.StartsWith("+"))
                    phone = $"+{phone}";
               
                var verificationCheck = await VerificationCheckResource.CreateAsync(
                  to: phone,
                  code: code,
                  pathServiceSid: _twilioConfiguration.PathServiceSid
              );
                return verificationCheck.Status == "approved";
            }
            catch (Exception ex)
            {

                return false;
            }
        }

     
    }
}
