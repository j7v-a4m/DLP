using DLP.API.Contracts.Course;
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
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private Guid currentUserId;

        public CoursesController(
            ICourseService courseService,
            IHttpContextAccessor httpContextAccessor)
        {
            this._courseService = courseService;
            currentUserId = new(httpContextAccessor.HttpContext.User.FindFirstValue("userId"));
        }

        [Authorize(Policy = "TeacherPolicy")]
        [HttpPost]
        public async Task<IResult> CreateCourse(
            [FromBody] CreateCourseRequest request)
        {
            
            await _courseService.CreateCourse(request.Title, request.Summary, currentUserId);
            return Results.Ok();
        }

        [Authorize(Policy = "TeacherPolicy")]
        [HttpGet("HelloGet")]
        public async Task<IResult> HelloGet()
        {
            return Results.Ok();
        }

        [HttpGet("GetAll")]
        public async Task<IResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCourses();
            return Results.Ok(courses);
        }

        [HttpGet("GetById")]
        public async Task<IResult> GetCourseById(Guid id)
        {
            var course = await _courseService.GetCourseById(id);
            return Results.Ok(course);
        }

        [Authorize(Policy = "TeacherPolicy")]
        [HttpPut]
        public async Task<IResult> Update(Guid id, [FromBody] UpdateCourseRequest request)
        {
            var course = await _courseService.GetCourseById(id);
            if(course.TeacherId != currentUserId)
                return (IResult)Unauthorized();
            await  _courseService.UpdateCourse(id, request.Title, request.Summary);
            return Results.Ok();
        }

        [Authorize(Policy = "TeacherPolicy")]
        [HttpDelete]
        public async Task<IResult> Delete(Guid id)
        {
            var course = await _courseService.GetCourseById(id);
            if (course.TeacherId != currentUserId)
                return (IResult)Unauthorized();
            await _courseService.DeleteCourse(id);
            return Results.Ok();
        }
    }
}
