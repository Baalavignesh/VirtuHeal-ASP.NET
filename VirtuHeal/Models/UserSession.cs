﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtuHeal.Models;

namespace VirtuHeal.Models
{
    public class UserSession
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public string ConnectionString { get; set; }

        public virtual User User { get; set; }

    }
}