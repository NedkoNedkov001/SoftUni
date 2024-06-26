﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Data.Models
{
    public class User
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; } = new List<UserTrip>();
    }
}

// Has an Id – a string, Primary Key
// Has a Username – a string with min length 5 and max length 20 (required)
// Has an Email - a string (required)
// Has a Password – a string with min length 6 and max length 20 - hashed in the database (required)
// Has UserTrips collection – a UserTrip type