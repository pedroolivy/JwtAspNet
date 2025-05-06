using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using JwtAspNet.Models;

namespace JwtAspNet.Services;

public class TokenService
{
    public string Create(User user)
    {
        var handler = new JwtSecurityTokenHandler();
        
        var key = Encoding.UTF8.GetBytes(Configuration.PrivateKey);
        
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key), 
            SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(2),
            Subject = GenetareClaims(user)
        };
        
        var token = handler.CreateToken(tokenDescriptor);
        
        return handler.WriteToken(token);
    }

    private static ClaimsIdentity GenetareClaims(User user)
    {
        var ci = new ClaimsIdentity();

        ci.AddClaim(new Claim("id", user.Id.ToString()));
        ci.AddClaim(new Claim(ClaimTypes.Name, user.Email));
        ci.AddClaim(new Claim(ClaimTypes.Email, user.Email));
        ci.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));
        ci.AddClaim(new Claim(ClaimTypes.Email, user.Email));
        ci.AddClaim(new Claim("image", user.Image));

        foreach (var role in user.Roles)
            ci.AddClaim(new Claim(ClaimTypes.Role, role));

        return ci;
    }
}