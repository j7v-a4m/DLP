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
    public class User : BaseEntity
    {
        private readonly List<Course> _myCourses = [];
        private readonly List<Subscription> _followedCourses = [];
        
        private User(
            Guid id,
            string firstName,
            string lastName,
            UserName userName,
            Email email,
            string passwordHash,
            Gender gender,
            bool isTeacher
            ):base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            Gender = gender;
            IsTeacher = isTeacher;
        }

        private User(
            Guid id,
            string firstName,
            string lastName,
            UserName userName,
            Email email,
            string passwordHash,
            Gender gender,
            bool isTeacher,
            Description aboutMe,
            ContactInfo contactInfo
            ) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            Gender = gender;
            IsTeacher = isTeacher;
            AboutMe = aboutMe;
            ContactInfo = contactInfo;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public UserName UserName { get; }
        public Email Email { get; }
        public string PasswordHash { get; }
        public Gender Gender { get; }
        public bool IsTeacher { get; }
        public Description? AboutMe { get; }
        public ContactInfo? ContactInfo { get; }
        public IReadOnlyList<Course> MyCourses => _myCourses;
        public IReadOnlyList<Subscription> FollowedCourses => _followedCourses;


        public static Result<User, Error> Create(
            Guid id,
            string firstName,
            string lastName,
            UserName userName,
            Email email,
            string passwordHash,
            Gender gender,
            bool isTeacher)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return Errors.General.ValueIsRequired();

            return new User(id, firstName, lastName, userName, email, passwordHash, gender, isTeacher);
        }

        public static Result<User, Error> Create(
            Guid id,
            string firstName,
            string lastName,
            UserName userName,
            Email email,
            string passwordHash,
            Gender gender,
            bool isTeacher,
            Description aboutMe,
            ContactInfo contactInfo)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return Errors.General.ValueIsRequired();

            return new User(id, firstName, lastName, userName, email, passwordHash, gender, isTeacher, aboutMe, contactInfo);
        }

        public void AddCourses(List<Course> myCourses) => _myCourses.AddRange(myCourses);
        public void AddFollowedCourses(List<Course> followedCourses) => _followedCourses.AddRange(_followedCourses);

    }
}
