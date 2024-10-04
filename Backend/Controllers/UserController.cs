using Backend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController()
    {
        _userService = new UserService();
    }
    
    [HttpPost]
    [ActionName("CreateUser")]
    public IActionResult CreateUser(string username)
    {
        _userService.AddUser(username);
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