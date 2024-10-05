using Backend.Model;

namespace Backend.Data;

public interface ITaskRepository
{
    public void AddTask(string title, string description, bool isCompleted, List<string> tags, UserModel createdBy, DateTime createdAt);
    
    public List<string> GetAllTask(string email);
    
    public void UpdateTask(string email, string title, string description, bool isCompleted, List<string> tags, UserModel createdBy, DateTime createdAt);
    
    public void DeleteTask(string email, Guid id);
}