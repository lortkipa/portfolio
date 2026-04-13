using Portfolio.Service.DTO.About;
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
        public ContactWithEmailJSDTO? Contact { get; set; }
        public AboutDTO? About { get; set; }
    }
}
