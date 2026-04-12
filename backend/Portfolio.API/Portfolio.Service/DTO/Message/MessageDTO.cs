using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portfolio.Service.DTO.Message
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool IsSeen { get; set; }
    }
}
