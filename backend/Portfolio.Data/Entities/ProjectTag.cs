using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portfolio.Data.Entities
{
    [Table("ProjectTags")]
    public class ProjectTag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int TagId { get; set; }

        // ProjectTags => Project
        public Project? Project { get; set; }
        // ProjectTags => Tag
        public Tag? Tag { get; set; }
    }
}
