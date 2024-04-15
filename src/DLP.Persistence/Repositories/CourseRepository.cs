using AutoMapper;
using DLP.Application.Interfaces.Repositories;
using DLP.Core.Models;
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
        private readonly AppDbContext _appDbContext;
        public CourseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task Create(Course course)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, string title, string description)
        {
            throw new NotImplementedException();
        }
    }
}
