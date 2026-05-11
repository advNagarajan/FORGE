using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FORGE.Infrastructure.Data;
using FORGE.Shared.Models;

namespace FORGE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ForgeDbContext _db;

    public UsersController(ForgeDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await _db.Users.ToListAsync());
    }
}