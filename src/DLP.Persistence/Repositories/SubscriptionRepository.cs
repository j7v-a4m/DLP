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
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly AppDbContext _context;
        public SubscriptionRepository(AppDbContext context)
        {
             _context = context;
        }

        public async Task AddSubscription(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task CancelSubscription(Guid userId, Guid courseId)
        {
            await _context.Subscriptions
                            .Where(
                                s => 
                                s.StudentId == userId && 
                                s.CourseId == courseId)
                            .ExecuteDeleteAsync();
        }

        public async Task<bool> CheckCourse(Guid courseId)
        {
            return await _context.Courses.AnyAsync(c => c.Id == courseId);
        }

        public Task<int> CountOfSubscriber(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountOfSubscription(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Subscription> GetSubscription(Guid userId, Guid courseId)
        {
            var subscription = await _context
                .Subscriptions
                .FirstOrDefaultAsync(u => u.StudentId == userId &&
                                            u.CourseId == courseId);
            return subscription;
        }
    }
}
