using SendEmail.Api.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Api.Business.Services.Interfaces
{
    public interface IUserService
    {

        Task<UserModel> CriarUsuario(UserModel user);
        Task<UserModel> ApagarUsuario(int id);
        Task<UserModel> ObterUsuarioPorId(int id);

    }
}
