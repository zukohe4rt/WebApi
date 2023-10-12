using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BaltaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;

namespace BaltaAPI.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("v1/[controller]")]

public class AuthController : ControllerBase
{
    private static User user = new();
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    [HttpPost("register")]
    public ActionResult<User> Register(Register request)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Senha);

        user.Email = request.Email;
        user.Senha = passwordHash;

        return Ok(user);
    }

    [HttpPost("login")]
    public ActionResult<User> Login(Register request)
    {
        if (user.Email != request.Email)
        {
            return BadRequest("Usuario não encontrado");
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Senha, user.Senha))
        {
            return BadRequest("Senha Incorreta.");
        }

        string token = CreateToken(user);
        
        return Ok(token);
    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value!));
        
        var credentials = new SigningCredentials(key,
            SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
            );

        string jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}