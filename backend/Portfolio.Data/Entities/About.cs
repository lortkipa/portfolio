using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portfolio.Data.Entities
{
    [Table("Abouts")]
    public class About
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string FullName { get; set; } = null!;
        [Required]
        [MaxLength(25)]
        public string JobTitle { get; set; } = null!;
        [Required]
        [MaxLength(250)]
        public string Bio { get; set; } = null!;
        [Required]
        [MaxLength(25)]
        public string StatusBadge { get; set; } = null!;
        [Required]
        [MaxLength(25)]
        public string FunBadge { get; set; } = null!;

        // About => User
        public User? User { get; set; }
    }
}
