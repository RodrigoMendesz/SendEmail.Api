using SendEmail.Api.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Api.Data.Repository.Interfaces
{
    public interface IUserPreferencesRepository
    {
        Task<UserPreferencesModel> GetUserPreferences(int userId);
        Task UpdateUserPreferences(UserPreferencesModel preferences);
    }
}
