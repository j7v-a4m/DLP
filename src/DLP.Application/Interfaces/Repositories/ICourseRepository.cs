using DLP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Application.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        Task Create(Course course);
        Task Delete(Guid id);
        Task<List<Course>> Get();
        Task<Course> GetById(Guid id);
        Task Update(Guid id, string title, string description);
    }
}
