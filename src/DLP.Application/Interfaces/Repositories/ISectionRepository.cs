using DLP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Application.Interfaces.Repositories
{
    public interface ISectionRepository
    {
        Task Create(Section section);
        Task Delete(Guid id);
        Task Update(Guid id, string title);
        Task<List<Section>> GetAllSections();
        Task<Section> GetSectionById(Guid id);
        Task<Course> GetCourseById(Guid sId);
    }
}
