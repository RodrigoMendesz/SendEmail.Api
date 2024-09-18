using SendEmail.Api.Data.DTOs;
using SendEmail.Api.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Api.Business.Services.Interfaces
{
    public interface IAuthService
    {
        UserModel Authenticate(string username, string password);
        string GenerateJwtToken(UserModel user);
    }
}
