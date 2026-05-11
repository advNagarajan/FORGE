using Microsoft.AspNetCore.Mvc;
using FORGE.Core.Repositories;
using FORGE.Shared.Models;

namespace FORGE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IRepository<User> _userRepository;

    public UsersController(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        await _userRepository.AddAsync(user);
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userRepository.GetAllAsync();
        return Ok(users);
    }
}