using DLP.Application.Interfaces.Services;
using DLP.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DLP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        private Guid currentUserId;
        public SubscriptionController(
            ISubscriptionService subscriptionService,
            IHttpContextAccessor httpContextAccessor)
        {
            _subscriptionService = subscriptionService;
            currentUserId = new(httpContextAccessor.HttpContext.User.FindFirstValue("userId"));
        }

        [Authorize(Policy = "StudentPolicy")]
        [HttpPost("GetSubscription")]
        public async Task<IResult> GetSubscription(Guid userId, Guid courseId)
        {
            if (userId != currentUserId)
                return (IResult)Unauthorized();

            var checkCourse = _subscriptionService.CheckCourse(courseId).Result;
            if (checkCourse == false)
                return (IResult)NotFound();
            
            var subscription = await _subscriptionService.GetSubscription(userId, courseId);
            if (subscription != null)
                return (IResult)BadRequest("You already subscribed this course.");

            subscription = new Subscription
            {
                StudentId = userId,
                CourseId = courseId
            };

            await _subscriptionService.AddSubscription(subscription);
            return Results.Ok();
        }

        [Authorize(Policy = "StudentPolicy")]
        [HttpDelete]
        public async Task<IResult> CancelSubscription(Guid userId, Guid courseId)
        {
            if (userId != currentUserId)
                return (IResult)Unauthorized();

            var checkCourse = _subscriptionService.CheckCourse(courseId).Result;
            if (checkCourse == false)
                return (IResult)NotFound();

            var subscription = await _subscriptionService.GetSubscription(userId, courseId);
            if (subscription == null)
                return (IResult)BadRequest("You are not subscribed this course.");

            await _subscriptionService.CancelSubscription(userId, courseId);
            return Results.Ok();
        }
    }
}
