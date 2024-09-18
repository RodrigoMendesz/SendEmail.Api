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
                var apiKey = "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";
                var client = new SendGridClient(apiKey);

                var from = new EmailAddress("mendes.dg151103@gmail.com", "Example User");

                var to = new EmailAddress(email.ToEmail);
                var subject = email.Subject;
                var plainTextContent = email.Body;
                var htmlContent = $"<strong>{email.Body}</strong>"; 
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Accepted)
                {
                    var errorMessage = await response.Body.ReadAsStringAsync();
                    throw new Exception($"Failed to send email: {response.StatusCode} - {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while sending the email: {ex.Message}", ex);
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
        public async Task<List<LogEmail>> GetEmailsSentInLastHour(int userId)
        {
            var oneHourAgo = DateTime.UtcNow.AddHours(-1);
            return await _appDbContext.EmailLogs
                .Where(e => e.UserId == userId && e.SentAt >= oneHourAgo)
                .ToListAsync();
        }

    }
}
