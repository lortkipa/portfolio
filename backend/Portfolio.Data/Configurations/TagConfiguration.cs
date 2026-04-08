using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Data.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags")
                .HasKey(t => t.Id);
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(25);
            builder.HasIndex(t => t.Name)
                .IsUnique();

            // Tag => SkillTags
            builder.HasMany(t => t.SkillTags)
                .WithOne(st => st.Tag)
                .HasForeignKey(st => st.TagId)
                .OnDelete(DeleteBehavior.Cascade);
            // Tag => ProjectTags
            builder.HasMany(t => t.ProjectTags)
                .WithOne(pg => pg.Tag)
                .HasForeignKey(pg => pg.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
