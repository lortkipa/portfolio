using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.DTO.About
{
    public class CreateAboutDTO
    {
        public string FullName { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public string Bio { get; set; } = null!;
        public string StatusBadge { get; set; } = null!;
        public string FunBadge { get; set; } = null!;
    }
}
