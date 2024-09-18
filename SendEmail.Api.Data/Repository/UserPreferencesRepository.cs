using SendEmail.Api.Data.Context;
using SendEmail.Api.Data.Model;
using SendEmail.Api.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Api.Data.Repository
{
    public class UserPreferencesRepository : IUserPreferencesRepository
    {
        private readonly AppDbContext _context;

        public UserPreferencesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserPreferencesModel> GetUserPreferences(int userId)
        {
            return await _context.UserPreferences.FindAsync(userId);
        }

        public async Task UpdateUserPreferences(UserPreferencesModel preferences)
        {
            var existingPreferences = await _context.UserPreferences.FindAsync(preferences.UserId);
            if (existingPreferences != null)
            {
                existingPreferences.Theme = preferences.Theme;
                existingPreferences.ColorScheme = preferences.ColorScheme;
                existingPreferences.Categories = preferences.Categories;
                existingPreferences.Labels = preferences.Labels;
            }
            else
            {
                await _context.UserPreferences.AddAsync(preferences);
            }
            await _context.SaveChangesAsync();

        }
    }
}

