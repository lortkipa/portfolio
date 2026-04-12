using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.DTO.Message
{
    public class CreateMessageDTO
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool IsSeen { get; set; }
    }
}
