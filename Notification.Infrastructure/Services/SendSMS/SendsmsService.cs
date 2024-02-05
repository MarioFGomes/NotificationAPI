using Notification.Domain.Repositories;
using Notification.Infrastructure.Services.SendEmail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Notification.Infrastructure.Services.SendSMS;
public class SendsmsService : ISendSmsService 
{
    private readonly SmsConfig _config;
  
    public SendsmsService(SmsConfig smsConfig)
    {
      _config = smsConfig;
    }
    public Task SendAsync(string content, string toPhoneNumber) 
    {
        try {

            TwilioClient.Init(_config.AccountSid, _config.AuthToken);

            var message = MessageResource.Create(
              body: content,
              from: new Twilio.Types.PhoneNumber(_config.FromNumber),
              to: new Twilio.Types.PhoneNumber(toPhoneNumber)
              );

         return Task.CompletedTask;

        }
        catch (Exception ex) 
        {
            throw new Exception(ex.Message);
        }
      
       
    }
}
