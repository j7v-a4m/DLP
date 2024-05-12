using System.ComponentModel.DataAnnotations;

namespace DLP.API.Contracts.Course
{
    public record UpdateCourseRequest(
        [Required] string Title,
        [Required] string Summary);
}
