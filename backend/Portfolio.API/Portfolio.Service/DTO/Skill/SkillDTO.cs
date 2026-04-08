using Portfolio.Service.DTO.Tag;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portfolio.Service.DTO.Skill
{
    public class SkillDTO
    {
        public int Id { get; set; }
        public string Icon { get; set; } = null!;
        public string Title { get; set; } = null!;
    }
}
