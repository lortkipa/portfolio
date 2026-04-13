using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.DTO.EmailJS
{
    public class EmailJSDTO
    {
        public int Id { get; set; }
        public string? ServiceId { get; set; }
        public string? TemplateId { get; set; }
        public string? PublicKey { get; set; }
    }
}
