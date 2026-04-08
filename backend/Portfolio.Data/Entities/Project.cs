using Portfolio.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portfolio.Data.Entities
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(8)]
        public string Icon { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(150)]
        public string Desc { get; set; } = null!;
        [Required]
        public ProjectThemes Theme { get; set; } = ProjectThemes.Orange;
        [MaxLength(100)]
        public string? githubLink { get; set; }
        [MaxLength(100)]
        public string? demoLink { get; set; }

        // Project => ProjetTags
        public ICollection<ProjectTag> ProjectTags { get; set; } = new List<ProjectTag>();
    }
}
