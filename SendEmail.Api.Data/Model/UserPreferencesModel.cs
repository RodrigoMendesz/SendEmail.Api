using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail.Api.Data.Model
{
    public class UserPreferencesModel
    {
        [Key]
        public int UserId { get; set; }
        public string Theme { get; set; }
        public string ColorScheme { get; set; }
        public string Categories { get; set; }
        public string Labels { get; set; }

    }
}
