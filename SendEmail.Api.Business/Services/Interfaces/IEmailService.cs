using SendEmail.Api.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Api.Business.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailSendModel email);
    }
}
