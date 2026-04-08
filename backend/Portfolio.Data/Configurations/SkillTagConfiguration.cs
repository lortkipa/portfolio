using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Data.Configurations
{
    public class SkillTagConfiguration : IEntityTypeConfiguration<SkillTag>
    {
        public void Configure(EntityTypeBuilder<SkillTag> builder)
        {
            builder.ToTable("SkillTags")
                .HasKey(st => st.Id);
            builder.Property(st => st.SkillId)
                .IsRequired();
            builder.Property(st => st.TagId)
                .IsRequired();

            // SkillTags => Skill
            builder.HasOne(st => st.Skill)
                .WithMany(s => s.SkillTags)
                .HasForeignKey(st => st.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
            // SkillTags => Tag
            builder.HasOne(st => st.Tag)
                .WithMany(t => t.SkillTags)
                .HasForeignKey(st => st.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
