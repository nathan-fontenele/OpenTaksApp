using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Backend.Model;

public class TaskModel
{
    [Key]
    public Guid Id { get; set; }
    
    [NotNull]
    [Required]
    public string Title { get; set; }

    public string Description { get; set; }
    
    public bool IsCompleted { get; set; }
    
    public List<string> Tags { get; set; }
    
    public Guid CreatedByUserId { get; set; }
    public UserModel CreatedBy { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; }
}