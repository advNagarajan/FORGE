using Microsoft.AspNetCore.Mvc;
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
    public async IActionResult CreateUser(User user)
    {
        await _db.Users.Add(user);
        await _db.SaveChanges();
        return Ok(user);
    }

    [HttpGet]
    public async IActionResult GetUsers()
    {
        return Ok(await _db.Users.ToListAsync());
    }
}