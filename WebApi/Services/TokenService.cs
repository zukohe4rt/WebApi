using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BaltaAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace BaltaAPI.Services;

public class TokenService
{
    public string Generate(User user)
    {
        var handler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(Settings.PrivateKey);
        
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor   
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(2),
        };
        
        var token = handler.CreateToken(tokenDescriptor);

        return  handler.WriteToken(token);
    }

}