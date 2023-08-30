using System.Text;
using Jkulds.Micro.Options.Base;
using Microsoft.IdentityModel.Tokens;

namespace Jkulds.Micro.Options.Jwt;

public class JwtOptions : BaseOption
{
    public string Key { get; set; } = string.Empty;
    public TimeSpan TokenExpire { get; set; } = TimeSpan.Zero;
    public TimeSpan RefreshTokenExpire { get; set; } = TimeSpan.Zero;
    public string Issuer { get; set; } = string.Empty;
    public string Algorithm { get; set; } = string.Empty;
    public byte[] KeyBytes => Encoding.ASCII.GetBytes(Key);

    public TokenValidationParameters GetTokenValidationParameters()
    {
        return new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(KeyBytes),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false,
            ValidateLifetime = false
        };
    }
}