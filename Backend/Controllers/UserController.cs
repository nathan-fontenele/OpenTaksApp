using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }
    
    [HttpPost]
    [Route("CreateUser")]
    [ActionName("CreateUser")]
    public IActionResult CreateUser(string firstname, string lastname, string email, string password)
    {
        _userService.AddUser(firstname, lastname, email, password);
        return Ok();
    }

    [HttpGet]
    [Route("GetAllUsers")]
    [ActionName("GetUsers")]
    public IActionResult GetUsers()
    {
        var users = _userService.GetUsers();
        return Ok(users);
    }
    
    [HttpGet]
    [Route("Login")]
    [ActionName("Login")]
    public IActionResult Login(string email, string password)
    {
        var user = _userService.Login(email, password);
        return Ok(user);
    }
    
}