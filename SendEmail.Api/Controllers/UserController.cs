using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendEmail.Api.Business.Services.Interfaces;
using SendEmail.Api.Data.DTOs;
using SendEmail.Api.Data.Model;

namespace SendEmail.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpPost("Cadastrar")]
        public async Task<ActionResult<UserDto>> CreteUser([FromBody] UserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = _mapper.Map<UserModel>(userDto);
                var NewUser = await _userService.CriarUsuario(user);
                return Ok();

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> DeleteUser(int id)
        {
            try
            {
                var user = await _userService.ApagarUsuario(id);
                if (user == null)
                {
                    return BadRequest(ModelState);
                }
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
