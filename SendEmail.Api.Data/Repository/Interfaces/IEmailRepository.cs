using SendEmail.Api.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Api.Data.Repository.Interfaces
{
    public interface IEmailRepository
    {
        Task<IEnumerable<EmailModel>> GetEmailsByUserIdAsync(int Id);
        Task<EmailModel> GetEmailByIdAsync(int Id);
        Task SendEmailAsync(EmailSendModel email);
        Task DeleteEmailAsync(int id);
    }
}
