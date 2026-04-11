using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portfolio.Service.DTO.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public int AboutId { get; set; }
    }
}
