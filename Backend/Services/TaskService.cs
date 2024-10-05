using Backend.Data;
using Backend.Model;

namespace Backend.Services;

public class TaskService
{
    private TaskRepository _taskRepository;
    
    public TaskService(TaskRepository taskRepository)
    {
        _taskRepository = taskRepository ?? throw new ArgumentException(nameof(taskRepository));
    }
    
    public void AddTask(string title, string description, bool isCompleted, List<string> tags, UserModel createdBy,
        DateTime createdAt)
    {
        if (string.IsNullOrEmpty(title))
        {
            throw new ArgumentException("Os campos de título e o email são obrigatórios.");
        }
        
        _taskRepository.AddTask(title, description, isCompleted, tags, createdBy, createdAt);
    }
    
}