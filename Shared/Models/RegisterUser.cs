using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Shared.Models
{
    public class RegisterUser
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, StringLength(50), MinLength(8)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage ="The passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
