using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.DTO.User
{
    public class UpdateUserDTO
    {
        public int ContactId { get; set; }
        public string FullName { get; set; } = null!;
    }
}
