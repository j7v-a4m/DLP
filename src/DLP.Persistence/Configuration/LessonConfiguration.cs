using DLP.Core.Models;
using DLP.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Persistence.Configuration
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.LessonUrl).IsRequired();
            builder.Property(l => l.ResourcesUrl).IsRequired(false);

            builder.
                Property(l => l.Title)
                .HasConversion(v => v.Value, v => Title.Create(v).Value)
                .IsRequired();

            builder.
                Property(l => l.Description)
                .HasConversion(v => v.Value, v => Description.Create(v).Value)
                .IsRequired();

            builder.
                HasOne(l => l.Section)
                .WithMany(s => s.Lessons)
                .HasForeignKey(l => l.SectionId)
                .IsRequired();

            builder.HasIndex(l => l.Title);
        }
    }
}
