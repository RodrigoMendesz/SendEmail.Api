using SendEmail.Api.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Api.Data.Repository
{
    public interface IUserRepository
    {
        Task<UserModel> CriaUsuario(UserModel user);
        Task<UserModel> DeletaUsuario(int id);
        Task<UserModel> GetById(int id);
    }
}
