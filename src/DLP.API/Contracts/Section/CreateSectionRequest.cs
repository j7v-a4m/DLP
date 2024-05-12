using System.ComponentModel.DataAnnotations;

namespace DLP.API.Contracts.Section
{
    public record CreateSectionRequest(
        [Required]string Title,
        [Required]Guid courseId);
}
