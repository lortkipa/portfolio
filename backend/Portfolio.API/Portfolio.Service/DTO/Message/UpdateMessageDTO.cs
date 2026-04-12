using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.DTO.Message
{
    public class UpdateMessageDTO
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
