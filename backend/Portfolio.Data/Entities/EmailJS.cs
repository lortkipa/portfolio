using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portfolio.Data.Entities
{
    [Table("EmailJS")]
    public class EmailJS
    {
        [Key]
        public int Id { get; set; }
        public string? ServiceId { get; set; }
        public string? TemplateId { get; set; }
        public string? PublicKey { get; set; }

        // EmailJS => Contact
        public Contact? Contact { get; set; }
    }
}
