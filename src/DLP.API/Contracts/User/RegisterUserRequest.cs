using System.ComponentModel.DataAnnotations;

namespace DLP.API.Contracts.User
{
    public record RegisterUserRequest(
        [Required] string FirstName,
        [Required] string LastName,
        [Required] string UserName,
        [Required] string Email,
        [Required] string Password,
        [Required] string Gender, 
        [Required] bool IsTeacher);
}
