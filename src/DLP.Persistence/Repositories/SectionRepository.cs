using DLP.Application.Interfaces.Repositories;
using DLP.Core.Models;
using DLP.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Persistence.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private readonly AppDbContext _context;

        public SectionRepository(AppDbContext context)
        {
             _context = context;
        }
        public async Task Create(Section section)
        {
            await _context.Sections.AddAsync(section);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id) =>
            await _context.Sections
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync();

        public async Task<List<Section>> GetAllSections() =>
            await _context.Sections.AsNoTracking().ToListAsync();

        public async Task<Course> GetCourseById(Guid sId)
        {
            var query = await _context.Sections
                    .Join(_context.Courses, s => s.CourseId, c => c.Id, 
                    (s, c) => new { Section = s, Course = c})
                    .FirstOrDefaultAsync(i => i.Section.Id == sId);
            return query.Course;
        }

        public async Task<Section> GetSectionById(Guid id) =>
            await _context.Sections.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id) ?? throw new Exception();

        public async Task Update(Guid id, string title)
        {
            var _title = Title.Create(title).Value;

            await _context.Sections
                .Where(s => s.Id == id)
                .ExecuteUpdateAsync(c => c
                    .SetProperty(s => s.Title, _title));
        }
            
    }
}
