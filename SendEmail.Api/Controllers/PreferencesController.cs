using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendEmail.Api.Business.Services.Interfaces;
using SendEmail.Api.Data.DTOs;
using SendEmail.Api.Data.Model;

namespace SendEmail.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferencesController : ControllerBase
    {
        private readonly IUserPreferencesService _preferencesService;
        private readonly IMapper _mapper;

        public PreferencesController(IUserPreferencesService preferencesService)
        {
            _preferencesService = preferencesService;
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdatePreferences(UserPreferencesDto preferencesDto)
        {
            var preferences = _mapper.Map<UserPreferencesModel>(preferencesDto);
            await _preferencesService.UpdatePreferencesAsync(preferences);
            return Ok("Preferences updated successfully.");
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetPreferences(int userId)
        {
            var preferences = await _preferencesService.GetPreferencesAsync(userId);
            if (preferences == null)
            {
                return NotFound("Preferences not found.");
            }
            return Ok(preferences);
        }
    }
}
