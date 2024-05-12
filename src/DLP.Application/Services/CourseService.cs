using DLP.Application.Interfaces.Repositories;
using DLP.Application.Interfaces.Services;
using DLP.Core.Models;
using DLP.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Application.Services
{
    public class CourseService: ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task CreateCourse(string title, string summary, Guid teacherId)
        {
            var _title = Title.Create(title).Value;
            var course = Course.Create(Guid.NewGuid(), _title, summary, teacherId);
            await _courseRepository.Create(course.Value);
        }

        public async Task DeleteCourse(Guid id)
        {
            await _courseRepository.Delete(id);
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _courseRepository.GetAll();
        }

        public async Task<Course> GetCourseById(Guid id)
        {
            return await _courseRepository.GetById(id);
        }

        public async Task UpdateCourse(Guid id, string title, string description)
        {
            await _courseRepository.Update(id, title, description);
        }
    }
}
