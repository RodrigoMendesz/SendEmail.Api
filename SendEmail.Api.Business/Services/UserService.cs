using SendEmail.Api.Business.Services.Interfaces;
using SendEmail.Api.Data.Model;
using SendEmail.Api.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Api.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public Task<UserModel> ApagarUsuario(int id) => _repository.DeletaUsuario(id);

        public Task<UserModel> CriarUsuario(UserModel user) => _repository.CriaUsuario(user);
        
        public Task<UserModel> ObterUsuarioPorId(int id) => _repository.GetById(id);
    }
}
