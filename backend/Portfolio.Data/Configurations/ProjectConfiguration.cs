using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Data.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects")
                .HasKey(p => p.Id);
            builder.Property(p => p.Icon)
               .IsRequired()
               .HasMaxLength(10)
               .IsUnicode(true);
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasIndex(p => p.Title)
                .IsUnique();
            builder.Property(p => p.Desc)
                .IsRequired()
                .HasMaxLength(150);
            builder.HasIndex(p => p.Desc)
                .IsUnique();
            builder.Property(p => p.Theme)
                .IsRequired();
            builder.Property(p => p.githubLink)
                .HasMaxLength(100);
            builder.HasIndex(p => p.githubLink)
                .IsUnique();
            builder.Property(p => p.demoLink)
                .HasMaxLength(100);
            builder.HasIndex(p => p.demoLink)
                .IsUnique();

            // Project => ProjetTags
            builder.HasMany(p => p.ProjectTags)
                .WithOne(pt => pt.Project)
                .HasForeignKey(pt => pt.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
