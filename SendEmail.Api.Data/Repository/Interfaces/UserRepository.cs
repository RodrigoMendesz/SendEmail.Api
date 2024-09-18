using SendEmail.Api.Data.Context;
using SendEmail.Api.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Api.Data.Repository.Interfaces
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<UserModel> CriaUsuario(UserModel user)
        {
            _appDbContext.Add(user);
            _appDbContext.SaveChanges();
            return user;

        }

        public async Task<UserModel> DeletaUsuario(int id)
        {
            var user = await GetById(id);
            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }
            _appDbContext.Remove(user);
            _appDbContext.SaveChanges();
            return user;
        }

        public async Task<UserModel> GetById(int id)
        {
            return _appDbContext.Users.Where(u => u.Id == id).FirstOrDefault();
        }
    }
}
