using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.DTO.User
{
    public class LoginUserDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
