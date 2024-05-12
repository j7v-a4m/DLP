using DLP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Application.Interfaces.Services
{
    public interface ISubscriptionService
    {
        Task AddSubscription(Subscription subscription);
        Task<Subscription> GetSubscription(Guid userId, Guid courseId);
        Task CancelSubscription(Guid userId, Guid courseId);
        Task<int> CountOfSubscription(Guid userId);
        Task<int> CountOfSubscriber(Guid courseId);
        Task<bool> CheckCourse(Guid courseId);
    }
}
