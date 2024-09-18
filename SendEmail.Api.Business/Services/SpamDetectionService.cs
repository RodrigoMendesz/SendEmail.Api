using SendEmail.Api.Business.Services.Interfaces;
using SendEmail.Api.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Api.Business.Services
{
    public class SpamDetectionService : ISpamDetectionService
    {
        private readonly IEmailRepository _emailRepository;

        public SpamDetectionService(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public async Task<bool> IsSpamAsync(int userId)
        {
            var recentEmails = await _emailRepository.GetEmailsSentInLastHour(userId);
            if (recentEmails.Count > 100) // Limite de e-mails enviados em uma hora
            {
                return true; // Detectado como spam
            }

            // Verifique palavras suspeitas, etc...
            var spamWords = new List<string> { "Grátis", "Ganhe dinheiro", "Oferta exclusiva" };
            foreach (var email in recentEmails)
            {
                if (spamWords.Any(word => email.Body.Contains(word)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
