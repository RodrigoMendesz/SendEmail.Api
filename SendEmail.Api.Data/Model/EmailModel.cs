using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Api.Data.Model
{
    public class EmailModel
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Recipient { get; set; }

        [Required]
        [StringLength(100)]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime SentAt { get; set; }
    }
}
