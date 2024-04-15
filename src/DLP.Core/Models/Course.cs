using CSharpFunctionalExtensions;
using DLP.Core.Common;
using DLP.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Core.Models
{
    public class Course : BaseEntity
    {
        private readonly List<Subscription> _students = [];
        private readonly List<Section> _sections = [];
        
        private Course(
            Guid id,
            Title title,
            string summary,
            Guid teacherId
            ): base(id)
        {
            Title = title;
            Summary = summary;
            TeacherId = teacherId;
        }

        private Course(
            Guid id,
            Title title,
            string summary,
            Guid teacherId,
            Description aboutCourse,
            string[] whatYouWillLearn,
            string[] initialRequirements
            ) : base(id)
        {
            Title = title;
            Summary = summary;
            TeacherId = teacherId;
            AboutCourse = aboutCourse;
            WhatYouWillLearn = whatYouWillLearn;
            InitialRequirements = initialRequirements;
        }

        public Title Title { get; }
        public string Summary { get; }
        public Description? AboutCourse { get; }
        public string[]? WhatYouWillLearn { get; }
        public string[]? InitialRequirements { get; }
        public Guid TeacherId { get; }
        [ForeignKey(nameof(TeacherId))]
        public User? Teacher { get; }
        public IReadOnlyList<Subscription> Students => _students;
        public IReadOnlyList<Section> Sections => _sections;

        public static Result<Course, Error> Create(Guid id,
            Title title,
            string summary,
            Guid teacherId)
        {
            return new Course(id, title, summary, teacherId);
        }

        public static Result<Course, Error> Create(Guid id,
            Title title,
            string summary,
            Guid teacherId,
            Description aboutCourse,
            string[] whatYouWillLearn,
            string[] initialRequirements)
        {
            return new Course(id, title, summary, teacherId, aboutCourse, whatYouWillLearn, initialRequirements);
        }

        public void AddStudents(List<Subscription> students) => _students.AddRange(students);
        public void AddSections(List<Section> sections) => _sections.AddRange(sections);
    }
}
