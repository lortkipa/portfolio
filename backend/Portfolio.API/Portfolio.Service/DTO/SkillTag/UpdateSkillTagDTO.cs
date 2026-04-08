using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portfolio.Service.DTO.SkillTag
{
    public class UpdateSkillTagDTO
    {
        public int SkillId { get; set; }
        public int TagId { get; set; }
    }
}
