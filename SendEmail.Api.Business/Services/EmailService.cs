using SendEmail.Api.Business.Services.Interfaces;
using SendEmail.Api.Data.Model;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Api.Business.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _sendGridApiKey = "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";
        public async Task SendEmailAsync(EmailSendModel email)
        {
            try
            {
                var client = new SendGridClient(_sendGridApiKey);
                var from = new EmailAddress("your-email@example.com", "Example Sender");
                var to = new EmailAddress(email.ToEmail);
                var msg = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
                var response = await client.SendEmailAsync(msg);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    // Handle error
                    throw new Exception($"Failed to send email: {response.StatusCode}");
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
