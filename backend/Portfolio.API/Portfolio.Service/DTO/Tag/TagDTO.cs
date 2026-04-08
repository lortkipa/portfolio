using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portfolio.Service.DTO.Tag
{
    public class TagDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
