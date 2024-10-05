using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Backend.Model;

[Table("Users")]
public class UserModel
{
    [Key]
    public Guid ID { get; set; }
    
    [NotNull]
    [MaxLength(50)]
    [Required]
    public string FirstName { get; set; }
    
    [NotNull]
    [MaxLength(50)]
    [Required]
    public string  LastName{ get; set; }
    
    [NotNull]
    [Required]
    [EmailAddress]
    public string  Email{ get; set; }
    
    [NotNull]
    [MaxLength(50)]
    [Required]
    public string Password { get; set; }
    
    public ICollection<TaskModel> Tasks { get; set; }
}