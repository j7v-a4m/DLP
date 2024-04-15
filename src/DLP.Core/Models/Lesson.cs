using CSharpFunctionalExtensions;
using DLP.Core.Common;
using DLP.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Core.Models
{
    public class Lesson: BaseEntity
    {
        private Lesson(
            Guid id,
            Title title,
            string lessonUrl,
            Description description,
            Guid sectionId) : base(id)
        {
            Title = title;
            LessonUrl = lessonUrl;
            Description = description;
            SectionId = sectionId;
        }

        private Lesson(
            Guid id, 
            Title title, 
            string lessonUrl, 
            Description description,
            string resourceUrl,
            Guid sectionId): base(id)
        {
            Title = title;
            LessonUrl = lessonUrl;
            Description = description;
            ResourcesUrl = resourceUrl;
            SectionId = sectionId;
        }

        public Title Title { get; }
        public string LessonUrl { get; }
        public Description Description { get; }
        public string? ResourcesUrl { get; } = string.Empty;

        public Guid SectionId { get; }
        public Section Section { get; }

        public static Result<Lesson, Error> Create(
            Guid id,
            Title title,
            string lessonUrl,
            Description description,
            Guid sectionId)
        {
            return new Lesson(id, title, lessonUrl, description, sectionId);
        }

        public static Result<Lesson, Error> Create(
            Guid id,
            Title title,
            string lessonUrl,
            Description description,
            string resourceUrl,
            Guid sectionId)
        {
            if (string.IsNullOrEmpty(lessonUrl))
                return Errors.General.ValueIsRequired();

            return new Lesson(id, title, lessonUrl, description, resourceUrl, sectionId);
        }
    }
}
