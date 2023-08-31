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
    public bool ValidateIssuer { get; set; } = false;
    public string Audience { get; set; } = string.Empty;
    public bool ValidateAudience { get; set; }
    public string Authority { get; set; } = string.Empty;
    public bool RequireHttpsMetadata { get; set; } = false;
    public string Algorithm { get; set; } = string.Empty;
    public byte[] KeyBytes => Encoding.ASCII.GetBytes(Key);

    public TokenValidationParameters GetTokenValidationParameters()
    {
        return new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(KeyBytes),
            ValidateIssuer = ValidateIssuer,
            ValidIssuer = Issuer,
            ValidateAudience = ValidateAudience,
            RequireExpirationTime = false,
            ValidateLifetime = false,
            ValidAudience = Audience,
        };
    }
}