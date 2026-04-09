using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.DTO.User
{
    public class CreateUserDTO
    {
        public int ContactId { get; set; }
        public string FullName { get; set; } = null!;
    }
}
