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
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;
        public SectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }
        public async Task CreateSection(string title, Guid courseId)
        {
            var _title = Title.Create(title).Value;
            var section = Section.Create(Guid.NewGuid(), _title, courseId);
            await _sectionRepository.Create(section.Value);
        }

        public async Task DeleteSection(Guid id) =>
            await _sectionRepository.Delete(id);

        public async Task<List<Section>> GetAllSections() =>
            await _sectionRepository.GetAllSections();

        public async Task<Course> GetCourse(Guid sId)
        {
            return await _sectionRepository.GetCourseById(sId);
        }

        public async Task<Section> GetSectionById(Guid id) =>
            await _sectionRepository.GetSectionById(id);

        public async Task UpdateSection(Guid id, string title) =>
            await _sectionRepository.Update(id, title);
    }
}
