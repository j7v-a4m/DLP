using DLP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Application.Interfaces.Services
{
    public interface ISectionService
    {
        Task CreateSection(string title, Guid courseId);
        Task DeleteSection(Guid id);
        Task UpdateSection(Guid id, string title);
        Task<List<Section>> GetAllSections();
        Task<Section> GetSectionById(Guid id);
        Task<Course> GetCourse(Guid sId);
    }
}
