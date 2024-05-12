using DLP.API.Contracts.User;
using DLP.Application.Interfaces.Services;
using DLP.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DLP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IResult> Register(
            RegisterUserRequest request)
        {
            await _userService.Register(
                request.FirstName, 
                request.LastName, 
                request.UserName, 
                request.Email, 
                request.Password, 
                request.Gender, 
                request.IsTeacher);
            return Results.Ok();
        }

        [HttpPost("login")]
        public async Task<IResult> Login(
            [FromBody] LoginUserRequest request)
        {
            var token = await _userService.Login(request.Email, request.Password);

            HttpContext.Response.Cookies.Append("tasty-cookies", token);

            return Results.Ok(token);
        }
    }
}
