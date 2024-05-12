using System.ComponentModel.DataAnnotations;

namespace DLP.API.Contracts.User
{
    public record LoginUserRequest(
        [Required] string Email,
        [Required] string Password);
}
