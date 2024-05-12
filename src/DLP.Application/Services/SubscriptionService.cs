using DLP.Application.Interfaces.Repositories;
using DLP.Application.Interfaces.Services;
using DLP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Application.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task AddSubscription(Subscription subscription)
        {
            await _subscriptionRepository.AddSubscription(subscription);
        }

        public async Task CancelSubscription(Guid userId, Guid courseId)
        {
            await _subscriptionRepository.CancelSubscription(userId, courseId);
        }

        public async Task<bool> CheckCourse(Guid courseId)
        {
            return await _subscriptionRepository.CheckCourse(courseId);
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
            return await _subscriptionRepository.GetSubscription(userId, courseId);
        }
    }
}
