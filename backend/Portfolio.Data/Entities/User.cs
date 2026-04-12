using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portfolio.Data.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ContactId { get; set; }
        [Required]
        public int AboutId { get; set; }
        [Required]
        [MaxLength(200)]
        public string PasswordHash { get; set; } = null!;

        // User => Contact
        public Contact? Contact { get; set; }
        // User => About
        public About? About { get; set; }
    }
}
