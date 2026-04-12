using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Data.Configurations
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.ToTable("Abouts")
                .HasKey(u => u.Id);
            builder.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(u => u.JobTitle)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(u => u.Bio)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(u => u.StatusBadge)
                .IsRequired()
                .HasMaxLength(25);
            builder.Property(u => u.FunBadge)
                .IsRequired()
                .HasMaxLength(25);

            // About => User
            builder.HasOne(a => a.User)
                .WithOne(u => u.About)
                .HasForeignKey<User>(u => u.AboutId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
