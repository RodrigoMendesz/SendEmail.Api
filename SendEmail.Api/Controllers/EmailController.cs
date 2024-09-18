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
        private readonly ISpamDetectionService _spamDetectionService;
        public EmailController(IEmailService service, IMapper mapper, ISpamDetectionService spamDetectionService)
        {
            _service = service;
            _mapper = mapper;
            _spamDetectionService = spamDetectionService;
        }
        [HttpPost("EnviarEmail")]
        public async Task<ActionResult<EmailModel>> SendEmail(EmailSendModel email)
        {
            try
            {
                var isSpam = await _spamDetectionService.IsSpamAsync(email.UserId);
                if (isSpam)
                {
                    return BadRequest("Email not sent: detected as spam.");
                }
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
