using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class RegisterViewModel
    {
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Email must be valid")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "{0} must be the same as {1}")]
        public string ConfirmPassword { get; set; }

    }
}
