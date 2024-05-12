using AutoMapper;
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
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task Create(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id) =>
            await _context.Courses
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();

        public async Task<List<Course>> GetAll() =>
            await _context.Courses.AsNoTracking().ToListAsync();

        public async Task<Course> GetById(Guid id) =>
            await _context.Courses.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception();

        public async Task Update(Guid id, string title, string summary)
        {
            var _title = Title.Create(title).Value;

            await _context.Courses
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.Title, _title)
                    .SetProperty(c => c.Summary, summary));
        }
    }
}
