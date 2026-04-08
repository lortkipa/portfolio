using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portfolio.Data.Entities
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; } = null!;

        // Tag => SkillTags
        public ICollection<SkillTag> SkillTags { get; set; } = new List<SkillTag>();
        // Tag => ProjectTags
        public ICollection<ProjectTag> ProjectTags { get; set; } = new List<ProjectTag>();
    }
}
