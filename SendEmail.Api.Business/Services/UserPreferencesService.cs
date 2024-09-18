using SendEmail.Api.Business.Services.Interfaces;
using SendEmail.Api.Data.Model;
using SendEmail.Api.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Api.Business.Services
{
    public class UserPreferencesService : IUserPreferencesService
    {
        private readonly IUserPreferencesRepository _preferencesRepository;

        public UserPreferencesService(IUserPreferencesRepository preferencesRepository)
        {
            _preferencesRepository = preferencesRepository;
        }

        public async Task<UserPreferencesModel> GetPreferencesAsync(int userId) =>  await _preferencesRepository.GetUserPreferences(userId);


        public async Task UpdatePreferencesAsync(UserPreferencesModel preferences) => await _preferencesRepository.UpdateUserPreferences(preferences);
    }
}
