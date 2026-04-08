using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portfolio.Data.Entities
{
    public class SkillTag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SkillId { get; set; }
        [Required]
        public int TagId { get; set; }

        // SkillTags => Skill
        public Skill? Skill { get; set; }
        // SkillTags => Tag
        public Tag? Tag { get; set; }
    }
}
