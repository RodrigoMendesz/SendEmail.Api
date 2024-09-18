using SendEmail.Api.Data.Context;
using SendEmail.Api.Data.Model;
using SendEmail.Api.Data.Repository.Interfaces;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SendEmail.Api.Data.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly string _sendGridApiKey = "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";
        public EmailRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<EmailModel> GetEmailByIdAsync(int Id)
        {
            return _appDbContext.Emails.Where(e => e.Id == Id).FirstOrDefault();
        }
        
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
        public async Task<IEnumerable<EmailModel>> GetEmailsByUserIdAsync(int userId)
        {
            var emails = await _appDbContext.Emails
                .Where(e => e.Id == userId)
                .ToListAsync();
            return emails;
        }
        public async Task DeleteEmailAsync(int id)
        {
            var email = _appDbContext.Emails.Where(e => e.Id == id).FirstOrDefault();
            _appDbContext.Emails.Remove(email);
            _appDbContext.SaveChanges();
        }

    }
}
