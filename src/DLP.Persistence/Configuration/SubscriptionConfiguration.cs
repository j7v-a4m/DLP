using DLP.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Persistence.Configuration
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(s => new { s.StudentId, s.CourseId });

            builder.
                HasOne(s => s.Course)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.
                HasOne(s => s.Student)
                .WithMany(s => s.FollowedCourses)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
