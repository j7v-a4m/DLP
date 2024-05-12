using DLP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Application.Interfaces.Services
{
    public interface ICourseService
    {
        Task CreateCourse(string title, string summary, Guid teacherId);
        Task DeleteCourse(Guid id);
        Task<List<Course>> GetAllCourses();
        Task<Course> GetCourseById(Guid id);
        Task UpdateCourse(Guid id, string title, string description);
    }
}
