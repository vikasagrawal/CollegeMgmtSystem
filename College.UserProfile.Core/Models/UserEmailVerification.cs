using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.UserProfile.Core.Models
{
    public class UserEmailVerification
    {
        [Required]
        public int UserLoginId { get; set; }
        [Required]
        public string VerificationCode { get; set; }
        public string ValidationError { get; set; }
    }
}
