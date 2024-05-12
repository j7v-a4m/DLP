using DLP.Core.Models;

namespace DLP.Infrastructure
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}