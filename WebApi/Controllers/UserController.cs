using BaltaAPI.Data;
using BaltaAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaltaAPI.Controllers;

[ApiController]
[Route("v1")]
[Authorize]

public class UserController : ControllerBase
{

    [HttpGet("users/buscar")]
    public async Task<IActionResult> GetAsync([FromServices] AppDbContext context)
    {
        var users = await context.Users.AsTracking().ToListAsync();
        return Ok(users);
    }
    
    [HttpGet("users/buscarPor{id}")]
    public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context, [FromRoute] int id)
    {
        var users = await context.Users.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
        return users == null
            ? NotFound()
            : Ok(users);
    }

    [HttpPost("users/adicionar")]
    public async Task<IActionResult> PostAsync([FromServices] AppDbContext context, User user)
    {
         await context.Users.AddAsync(user);
         await context.SaveChangesAsync();

         return Ok(user);
    }

    [HttpPut("users/editar")]
    public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromBody] User users)
    {
        
        try
        {
            context.Users.Update(users);
            await context.SaveChangesAsync();
            return Ok(users);
        }
        catch (Exception e)
        {
            return BadRequest();
        }

    }
    
    [HttpDelete("users/deletar{id}")]
    public async Task<IActionResult> DeleteAsync([FromServices] AppDbContext context, int id)
    {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return BadRequest();
            }
            
            try
            {
                    context.Users.Remove(user);
                    await context.SaveChangesAsync();

                    return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            
    }
    
}
    