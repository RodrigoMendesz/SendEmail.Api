using SendEmail.Api.Business.Services.Interfaces;
using SendEmail.Api.Data.Model;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendEmail.Api.Data.Repository.Interfaces;

namespace SendEmail.Api.Business.Services
{
    public class EmailService : IEmailService
    {
       private readonly IEmailRepository _repository;
        public EmailService(IEmailRepository emailRepository)
        {
            _repository = emailRepository;
        }
        public Task<EmailModel> GetEmailByIdAsync(int Id) => _repository.GetEmailByIdAsync(Id);

        public Task<IEnumerable<EmailModel>> GetEmailsByUserIdAsync(int Id) => _repository.GetEmailsByUserIdAsync(Id);

        public Task SendEmailAsync(EmailSendModel email) => _repository.SendEmailAsync(email);
        
        public Task DeleteEmailAsync(int id) => _repository.DeleteEmailAsync(id);
    }
}
