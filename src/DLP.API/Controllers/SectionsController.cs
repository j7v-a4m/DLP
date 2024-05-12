using DLP.API.Contracts.Section;
using DLP.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DLP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private readonly ISectionService _sectionService;
        private readonly ICourseService _courseService;
        private Guid currentUserId;


        public SectionsController(
            ISectionService sectionService, 
            ICourseService courseService,
            IHttpContextAccessor httpContextAccessor)
        {
            _sectionService = sectionService;
            _courseService = courseService;
            currentUserId = new(httpContextAccessor.HttpContext.User.FindFirstValue("userId"));

        }

        [Authorize(Policy = "TeacherPolicy")]
        [HttpPost]
        public async Task<IResult> Create([FromBody] CreateSectionRequest request)
        {
            var course = await _courseService.GetCourseById(request.courseId);
            if (course.TeacherId != currentUserId)
                return (IResult)Unauthorized();
            await _sectionService.CreateSection(request.Title, request.courseId);
            return Results.Ok();
        }

        [Authorize(Policy = "TeacherPolicy")]
        [HttpPut]
        public async Task<IResult> Update(Guid id, string title)
        {
            var course = await _sectionService.GetCourse(id);
            if(course.TeacherId != currentUserId)
                return (IResult)Unauthorized();
            await _sectionService.UpdateSection(id, title);
            return Results.Ok();
        }

        [Authorize(Policy = "TeacherPolicy")]
        [HttpDelete]
        public async Task<IResult> Delete(Guid id)
        {
            var course = await _sectionService.GetCourse(id);
            if (course.TeacherId != currentUserId)
                return (IResult)Unauthorized();
            await _sectionService.DeleteSection(id);
            return Results.Ok();
        }

        [HttpGet("GetAllSections")]
        public async Task<IResult> GetAllSections()
        {
            await _sectionService.GetAllSections();
            return Results.Ok();
        }

        [HttpGet("GetSectionById")]
        public async Task<IResult> GetSectionById(Guid id)
        {
            await _sectionService.GetSectionById(id);
            return Results.Ok();
        }
    }
}
