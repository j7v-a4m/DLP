using DLP.Application.Interfaces.Repositories;
using DLP.Core.Models;
using DLP.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Npgsql.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Persistence.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UsersRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user); ;
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var allUsers = await _context.Users.ToListAsync();
            var user = allUsers.FirstOrDefault(u => u.Email.Value == email) ?? throw new Exception();

            return user;
        }
    }
}
