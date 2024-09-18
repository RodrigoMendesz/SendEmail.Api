using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Api.Data.Model
{
    public class LogEmail
    {
        public int Id { get; set; }  
        public int UserId { get; set; }  
        public string ToEmail { get; set; } 
        public string Subject { get; set; }  
        public string Body { get; set; }  
        public DateTime SentAt { get; set; }  
    }
}
