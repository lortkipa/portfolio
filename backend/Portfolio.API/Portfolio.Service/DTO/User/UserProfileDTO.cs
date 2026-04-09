using Portfolio.Service.DTO.Contact;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.DTO.User
{
    public class UserProfileDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public ContactDTO? Contact { get; set; }
    }
}
