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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.PasswordHash).IsRequired(false);
            builder.Property(u => u.IsTeacher).IsRequired();

            builder.
                HasMany(u => u.MyCourses)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId)
                .IsRequired();

            builder.
                Property(u => u.UserName)
                .HasConversion(v => v.Value, v => UserName.Create(v).Value)
                .HasMaxLength(50)
                .IsRequired();

            builder.
                Property(u => u.Email)
                .HasConversion(v => v.Value, v => Email.Create(v).Value)
                .IsRequired();

            builder.
                Property(u => u.Gender)
                .HasConversion(v => v.Value, v => Gender.Create(v).Value)
                .IsRequired();

            //builder.
            //    Property(u => u.AboutMe)
            //    .HasConversion(v => v.Value, v => Description.Create(v).Value)
            //    .HasMaxLength(1000)
            //    .IsRequired();

            //builder.
            //    Property(u => u.ContactInfo)
            //    .HasConversion(v => v.PhoneNumber, v => ContactInfo.Create(v).Value)
            //    .HasConversion(v => v.TelegramLink, v => ContactInfo.Create(v).Value)
            //    .HasConversion(v => v.WebSiteUrl, v => ContactInfo.Create(v).Value)
            //    .HasConversion(v => v.YouTubeUrl, v => ContactInfo.Create(v).Value)
            //    .IsRequired();

            //builder.
            //    OwnsOne(u => u.ContactInfo, contactBuilder =>
            //    {
            //        contactBuilder.Property(c => c.PhoneNumber).IsRequired();
            //        contactBuilder.Property(c => c.TelegramLink).IsRequired(false);
            //        contactBuilder.Property(c => c.WebSiteUrl).IsRequired(false);
            //        contactBuilder.Property(c => c.YouTubeUrl).IsRequired(false);

            //    });

            builder.HasIndex(u => new { u.UserName, u.Email }).IsUnique();
        }
    }
}
