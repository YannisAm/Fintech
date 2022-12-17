﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Shared.Models
{
    public class User
    {
        [Key]
        [MaxLength(100)]
        public string Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt{ get; set; }
        public DateTime DateTimeCreated { get; set; } = DateTime.UtcNow;
    }
}
