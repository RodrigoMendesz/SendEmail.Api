using SendEmail.Api.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Api.Business.Services.Interfaces
{
    public interface IUserPreferencesService
    {
        Task<UserPreferencesModel> GetPreferencesAsync(int userId);
        Task UpdatePreferencesAsync(UserPreferencesModel preferences);
    }
}
