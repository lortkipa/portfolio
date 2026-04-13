using Portfolio.Service.DTO.EmailJS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.DTO.Contact
{
    public class ContactWithEmailJSDTO
    {
        public int Id { get; set; }
        public EmailJSDTO? EmailJS { get; set; }
        public string Email { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? GithubLink { get; set; }
        public string? LinkedinLink { get; set; }
    }
}
