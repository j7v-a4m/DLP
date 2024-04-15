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
    public class Section: BaseEntity
    {
        private readonly List<Lesson> _lessons = [];

        private Section(Guid id, Title title, Guid courseId): base(id)
        {
            Title = title;
            CourseId = courseId;
        }
        
        public Title Title { get; }
        public Guid CourseId { get; }
        public Course? Course { get; }
        public IReadOnlyList<Lesson>? Lessons => _lessons;

        public static Result<Section, Error> Create(Guid id, Title title, Guid courseId)
        {
            return new Section(id, title, courseId);
        }

        public void AddSection(List<Lesson> lessons) => _lessons.AddRange(lessons);
    }
}
