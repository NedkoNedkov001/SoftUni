﻿using Andreys.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Andreys.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public Gender Gender { get; set; }
    }
}
//Has an Id – int, Primary key
// Has a Name – a string with min length 4 and max length 20 (inclusive) (required)
// Has a Description – a string with max length 10 (inclusive)
// Has a ImageUrl – a string
// Has a Price – a decimal (required)
// Has a Category – an Enum – option between (Shirt, Denim, Shorts, Jacket) (required)
// Has a Gender – an Enum – option between (Male and Female) (required)