using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Andreys.Data.Models
{
    public class User : IdentityUser<string>
    {
        //[Key]
        //public string Id { get; set; } = Guid.NewGuid().ToString();

        //[Required]
        //[StringLength(10)]
        //public string Username { get; set; }

        //[Required]
        //[StringLength(36)]
        //public string Password { get; set; }

        //public string Email { get; set; }
    }
}
// Has an Id – GUID-string, Primary key
// Has a Username – a string with min length 4 and max length 10 (inclusive) (required)
// Has a Password – a string with min length 6 and max length 20 (inclusive) -hashed in the database
//(required)
// Has an Email