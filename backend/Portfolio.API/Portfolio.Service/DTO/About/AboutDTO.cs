using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portfolio.Service.DTO.About
{
    public class AboutDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public string Bio { get; set; } = null!;
        public string StatusBadge { get; set; } = null!;
        public string FunBadge { get; set; } = null!;
    }
}
