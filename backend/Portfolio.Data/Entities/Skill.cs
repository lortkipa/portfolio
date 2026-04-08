using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portfolio.Data.Entities
{
    [Table("Skills")]
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(8)]
        public string Icon { get; set; } = null!;
        [Required]
        [MaxLength(25)]
        public string Title { get; set; } = null!;

        // Skill => SkillTags
        public ICollection<SkillTag> SkillTags { get; set; } = new List<SkillTag>();
    }
}
