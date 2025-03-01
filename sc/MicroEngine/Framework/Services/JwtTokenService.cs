using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MicroEngine.Common;
using MicroEngine.Framework.Entity;
using MicroEngine.Framework.Services.Interface;
using Microsoft.IdentityModel.Tokens;

namespace MicroEngine.Framework.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly WebApiSetting _webApiSetting;

        public JwtTokenService(WebApiSetting webApiSetting)
        {
            _webApiSetting = webApiSetting;
        }

        public virtual string GetNewJwtToken(User user, long expireSeconds = 0L)
        {
            DateTimeOffset now = DateTimeOffset.Now;
            long num = now.AddDays(_webApiSetting.TokenLifetimeDays).ToUnixTimeSeconds();
            if (expireSeconds > 0)
            {
                num = expireSeconds;
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim("nbf", now.ToUnixTimeSeconds().ToString()),
                new Claim("exp", num.ToString()),
                new Claim("Id", user.Id.ToString()),
                new Claim(WebApiCommonDefaults.LoginName, user.LoginName),
                new Claim(WebApiCommonDefaults.UserName, user.Username),
                new Claim(WebApiCommonDefaults.UserCode, user.UserCode),
                new Claim(WebApiCommonDefaults.BranchCode, user.BranchCode),
            };
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            byte[] bytes = Encoding.UTF8.GetBytes(_webApiSetting.SecretKey);
            SigningCredentials signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(bytes),
                SecurityAlgorithms.HmacSha512Signature
            );

            JwtSecurityToken token = new JwtSecurityToken(
                new JwtHeader(signingCredentials),
                new JwtPayload(claims)
            );
            return jwtSecurityTokenHandler.WriteToken(token);
        }
    }
}
