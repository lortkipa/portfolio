using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Data.Configurations
{
    public class EmailJSConfiguration : IEntityTypeConfiguration<EmailJS>
    {
        public void Configure(EntityTypeBuilder<EmailJS> builder)
        {
            builder.ToTable("EmailJS")
                .HasKey(e => e.Id);

            // EmailJS => Contact
            builder.HasOne(e => e.Contact)
                .WithOne(c => c.EmailJS)
                .HasForeignKey<Contact>(c => c.EmailJSId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
