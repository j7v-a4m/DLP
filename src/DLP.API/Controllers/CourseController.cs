using DLP.API.Contracts.Course;
using DLP.Application.Interfaces.Services;
using DLP.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DLP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            this._courseService = courseService;
        }

        [HttpPost]
        public async Task<IResult> CreateCourse([FromBody] CreateCourseRequest request)
        {
            

            return Results.Ok();
        }
    }
}
