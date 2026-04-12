using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Data.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages")
                .HasKey(m => m.Id);
            builder.Property(c => c.Date)
                .IsRequired()
                .HasColumnType("datetime");
            builder.Property(m => m.FullName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);
            builder.Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(254);
            builder.Property(m => m.Subject)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);
            builder.Property(m => m.Content)
                .IsRequired()
                .HasMaxLength(5000)
                .IsUnicode(true);
        }
    }
}
