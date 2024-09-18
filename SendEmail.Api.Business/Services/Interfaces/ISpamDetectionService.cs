using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Api.Business.Services.Interfaces
{
    public interface ISpamDetectionService
    {
        Task<bool> IsSpamAsync(int userId);
    }
}
