using System.Text;
using Jkulds.Micro.Options.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Jkulds.Micro.Options.Jwt;

/// <summary>
/// Jwt options for appsettings.json
/// for process add "Jwt" key to appsettings.json with fields described after
/// </summary>
public class JwtOptions : BaseOption
{
    public string Key { get; set; } = string.Empty;
    public bool? RequireExpirationTime { get; set; }
    public bool? ValidateIssuerSigningKey { get; set; } 
    public string? Issuer { get; set; }
    public bool? ValidateIssuer { get; set; }
    public string? Audience { get; set; }
    public bool? ValidateAudience { get; set; }
    public bool? ValidateLifetime { get; set; }
    public string Algorithm { get; set; } = string.Empty;
    private byte[] KeyBytes => Encoding.ASCII.GetBytes(Key);
    
    public TimeSpan TokenExpire { get; set; } = TimeSpan.Zero;
    public TimeSpan RefreshTokenExpire { get; set; } = TimeSpan.Zero;

    /// <summary>
    /// option for JwtBearerOptions <see cref="JwtBearerOptions.RequireHttpsMetadata"/>
    /// </summary>
    public bool? RequireHttpsMetadata { get; set; }
    
    public string? Authority { get; set; }

    /// <summary>
    /// option for JwtBearerOptions <see cref="JwtBearerOptions.Authority"/>
    /// </summary>
    public TokenValidationParameters GetTokenValidationParameters()
    {
        var result = new TokenValidationParameters();
        result.IssuerSigningKey = new SymmetricSecurityKey(KeyBytes);

        if (ValidateIssuerSigningKey.HasValue)
        {
            result.ValidateIssuerSigningKey = ValidateIssuerSigningKey.Value;
        }

        if (ValidateIssuer.HasValue)
        {
            result.ValidateIssuer = ValidateIssuer.Value;
        }
        
        if (ValidateAudience.HasValue)
        {
            result.ValidateIssuer = ValidateAudience.Value;
        }

        if (!string.IsNullOrEmpty(Issuer))
        {
            result.ValidIssuer = Issuer;
        }
        
        if (!string.IsNullOrEmpty(Audience))
        {
            result.ValidAudience = Audience;
        }

        if (RequireExpirationTime.HasValue)
        {
            result.RequireExpirationTime = RequireExpirationTime.Value;
        }

        if (ValidateLifetime.HasValue)
        {
            result.ValidateLifetime = ValidateLifetime.Value;
        }

        return result;;
    }

    public void AddAuthorityToOptions(JwtBearerOptions jwtOptions)
    {
        if (!string.IsNullOrEmpty(Authority))
        {
            jwtOptions.Authority = Authority;
        }
    }
    
    public void AddRequireHttpsMetadataToOptions(JwtBearerOptions jwtOptions)
    {
        if (RequireHttpsMetadata.HasValue)
        {
            jwtOptions.RequireHttpsMetadata = RequireHttpsMetadata.Value;
        }
    }
}