using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    // Constructor Injection of UserService
    public UserController(UserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }
    
    [HttpPost]
    [ActionName("CreateUser")]
    public IActionResult CreateUser(string firstname, string lastname, string email, string password)
    {
        _userService.AddUser(firstname, lastname, email, password);
        return Ok();
    }

    [HttpGet]
    [ActionName("GetUsers")]
    public IActionResult GetUsers()
    {
        var users = _userService.GetUsers();
        return Ok(users);
    }
}