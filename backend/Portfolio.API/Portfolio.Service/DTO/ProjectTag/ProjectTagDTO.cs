using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portfolio.Service.DTO.ProjectTag
{
    public class ProjectTagDTO
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int TagId { get; set; }
    }
}
