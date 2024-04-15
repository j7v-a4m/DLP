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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Summary).IsRequired();
            builder.Property(c => c.WhatYouWillLearn).IsRequired(false);
            builder.Property(c => c.InitialRequirements).IsRequired(false);

            // User(Teacher) -> Course
            builder.
                HasOne(c => c.Teacher)
                .WithMany(u => u.MyCourses)
                .HasForeignKey(c => c.TeacherId)
                .IsRequired();

            builder.
                Property(c => c.Title)
                .HasConversion(v => v.Value, v => Title.Create(v).Value)
                .IsRequired();

            builder.
                Property(c => c.AboutCourse)
                .HasConversion(v => v.Value, v => Description.Create(v).Value)
                .IsRequired(false);

            builder.HasIndex(c => new { c.Title, c.Summary, c.WhatYouWillLearn });
        }
    }
}
