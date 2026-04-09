using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users")
                .HasKey(u => u.Id);
            builder.Property(u => u.ContactId)
                .IsRequired();
            builder.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(25);

            // User => Contact
            builder.HasOne(u => u.Contact)
                .WithOne(c => c.User)
                .HasForeignKey<User>(u => u.ContactId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
