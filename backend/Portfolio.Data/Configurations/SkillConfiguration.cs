using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Data.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skills")
                .HasKey(t => t.Id);
            builder.Property(t => t.Icon)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(true);
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(25);
            builder.HasIndex(t => t.Title)
                .IsUnique();

            // Skill => SkillTags
            builder.HasMany(s => s.SkillTags)
                .WithOne(st => st.Skill)
                .HasForeignKey(st => st.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
