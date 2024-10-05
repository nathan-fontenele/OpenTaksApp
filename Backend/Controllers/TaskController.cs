using Backend.Model;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly TaskService _taskService;
    
    public TaskController(TaskService taskService)
    {
        _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
    }
    
    [HttpPost]
    [Route("CreateTask")]
    [ActionName("CreateTask")]
    public IActionResult CreateTask([FromBody] TaskModel task)
    {
        _taskService.AddTask(task.Title, task.Description, task.IsCompleted, task.Tags, task.CreatedBy, task.CreatedAt);
        return Ok();
    }
}