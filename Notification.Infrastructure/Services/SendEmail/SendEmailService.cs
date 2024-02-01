using MimeKit;
using MailKit.Net.Smtp;
using SendGrid;
using SendGrid.Helpers.Mail;
using Notification.Domain.Repositories;
using System.Runtime.CompilerServices;

namespace Notification.Infrastructure.Services.SendEmail; 
public class SendEmailService : ISendEmailService 
{
    private readonly MailConfig _config;
    private readonly ISendGridClient _sendGridClient;
    public SendEmailService(ISendGridClient sendGridClient, MailConfig config)
    {
        _config = config;
        _sendGridClient = sendGridClient;
    }

    public async Task SendAsync(string subject, string content, string toEmail, string toName) 
    {
        try {
            var from = new EmailAddress(_config.FromEmail, _config.FromName);
            var to = new EmailAddress(toEmail, toName);

            var message = new SendGridMessage {
                From = from,
                Subject = subject
            };

            message.AddContent(MimeType.Html, content);
            message.AddTo(to);

            message.SetClickTracking(false, false);
            message.SetOpenTracking(false);
            message.SetGoogleAnalytics(false);
            message.SetSubscriptionTracking(false);

            await _sendGridClient.SendEmailAsync(message);
        }catch (Exception ex) 
        {

        }
    }

    public async Task  SendNativeAsync(string subject, string content, string toEmail, string toName) {
        var email = new MimeMessage();

        email.From.Add(new MailboxAddress("Mário Gomes", "sender@email.com"));
        email.To.Add(new MailboxAddress("Receiver Name", "receiver@email.com"));
        email.Subject = "Testing out email sending";

        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
            Text = "<b>Hello all the way from the land of C#</b>"
        };

        using (var smtp = new SmtpClient()) {
            smtp.Connect("smtp.gmail.com", 587, false);

            // Note: only needed if the SMTP server requires authentication
            smtp.Authenticate("smtp_username", "smtp_password");

            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
