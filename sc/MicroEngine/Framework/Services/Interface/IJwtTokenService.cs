using MicroEngine.Framework.Entity;

namespace MicroEngine.Framework.Services.Interface
{
    public interface IJwtTokenService
    {
        string GetNewJwtToken(User user, long expireSeconds = 0L);
    }
}
