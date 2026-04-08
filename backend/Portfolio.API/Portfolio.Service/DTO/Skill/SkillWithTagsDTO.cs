using Portfolio.Service.DTO.Tag;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.DTO.Skill
{
    public class SkillWithTagsDTO
    {
        public int Id { get; set; }
        public string Icon { get; set; } = null!;
        public string Title { get; set; } = null!;
        public List<TagDTO> Tags { get; set; } = new();
    }
}
