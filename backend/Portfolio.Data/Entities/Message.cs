using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portfolio.Data.Entities
{
    [Table("Messages")]
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;
        [Required]
        [MaxLength(254)]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Subject { get; set; } = null!;
        [Required]
        [MaxLength(5000)]
        public string Content { get; set; } = null!;
    }
}
