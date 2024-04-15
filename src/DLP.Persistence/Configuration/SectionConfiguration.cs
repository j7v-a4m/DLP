using DLP.Core.Models;
using DLP.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Persistence.Configuration
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(s => s.Id);

            builder.
                HasOne(s => s.Course)
                .WithMany(s => s.Sections)
                .HasForeignKey(s => s.CourseId)
                .IsRequired();

            builder.
                HasMany(s => s.Lessons)
                .WithOne(l => l.Section)
                .HasForeignKey(l => l.SectionId)
                .IsRequired();

            builder.
                Property(s => s.Title)
                .HasConversion(v => v.Value, v => Title.Create(v).Value)
                .IsRequired();

            builder.HasIndex(s => s.Title);
        }
    }
}
