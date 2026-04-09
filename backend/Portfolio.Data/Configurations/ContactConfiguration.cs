using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts")
                .HasKey(c => c.Id);
            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(254);
            builder.Property(c => c.Location)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(c => c.GithubLink)
                .HasMaxLength(100);
            builder.Property(c => c.LinkedinLink)
                .HasMaxLength(100);

            // Contact => User
            builder.HasOne(c => c.User)
                .WithOne(u => u.Contact)
                .HasForeignKey<User>(u => u.ContactId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
