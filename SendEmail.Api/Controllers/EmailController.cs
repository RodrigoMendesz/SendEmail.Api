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
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _service;
        private readonly IMapper _mapper;
        public EmailController(IEmailService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpPost("EnviarEmail")]
        public async Task<ActionResult<EmailDto>> SendEmail(EmailSendModel email)
        {
            try
            {
                _service.SendEmailAsync(email);
                return Ok(email); 
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
