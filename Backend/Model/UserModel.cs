using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Backend.Model;

[Table("Users")]
public class UserModel
{
    [Key]
    public int ID { get; set; }
    
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
    public string  Email{ get; set; }
    
    [NotNull]
    [MaxLength(50)]
    [Required]
    public string Password { get; set; }
}