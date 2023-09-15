﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(30)]
        public string? FullName { get; set; } = null;
        [Required]
        [StringLength(100)]  
        public string? Username { get; set; }
        [Required]
        [StringLength(40)]
        public string? Password { get; set; }
        public bool Locked { get; set; }=false;
        public DateTime CreatedAt { get; set; }= DateTime.Now;  
    }
}
