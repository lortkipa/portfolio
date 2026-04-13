using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portfolio.Data.Entities
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EmailJSId { get; set; }
        [Required]
        [MaxLength(254)]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Location { get; set; } = null!;
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = null!;
        [MaxLength(100)]
        public string? GithubLink { get; set; }
        [MaxLength(100)]
        public string? LinkedinLink { get; set; }

        // Contact => User
        public User? User { get; set; }
        // Contact => EmailJS
        public EmailJS? EmailJS { get; set; }
    }
}