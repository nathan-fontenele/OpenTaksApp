using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class TaskRepository : ITaskRepository
{
    private AppDbContext _context;
    private TaskModel _taskModel;

    public TaskRepository()
    {
        _context = new AppDbContext(new DbContextOptions<AppDbContext>());
        _taskModel = new TaskModel();
    }
    
    public void AddTask(string title, string description, bool isCompleted, List<string> tags, UserModel createdBy,
        DateTime createdAt)
    {
        _taskModel.Title = title;
        _taskModel.Description = description;
        _taskModel.IsCompleted = isCompleted;
        _taskModel.Tags = tags;
        _taskModel.CreatedBy = createdBy;
        _taskModel.CreatedAt = DateTime.Now.Date;
        
        _context.Tasks.Add(_taskModel);
        _context.SaveChanges();
    }

    public List<string> GetAllTask(string email)
    {
        var taskProperties = _context.Tasks
            .Where(t => t.CreatedBy.Email == email)
            .Select(t => new List<string>{t.Title, t.Description, t.IsCompleted.ToString(), t.Tags.ToString(), t.CreatedBy.Email, t.CreatedAt.ToString()})
            .ToList();
        
        return taskProperties.FirstOrDefault();
    }

    public void UpdateTask(string email, string title, string description, bool isCompleted, List<string> tags, UserModel createdBy,
        DateTime createdAt)
    {
        throw new NotImplementedException();
    }

    public void DeleteTask(string email, Guid id)
    {
        var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
        _context.Tasks.Remove(task);
        _context.SaveChanges();
    }
}