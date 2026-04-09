using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portfolio.Service.DTO.Contact
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? GithubLink { get; set; }
        public string? LinkedinLink { get; set; }
    }
}
