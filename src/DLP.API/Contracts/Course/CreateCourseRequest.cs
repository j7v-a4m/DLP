using System.ComponentModel.DataAnnotations;

namespace DLP.API.Contracts.Course
{
    public record CreateCourseRequest(
        [Required] string Title,
        [Required] string Description,
        Guid TeacherId);
}
