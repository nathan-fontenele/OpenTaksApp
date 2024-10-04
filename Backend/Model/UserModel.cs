using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Backend.Model;

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
    [MaxLength(50)]
    [Required]
    public string Password { get; set; }
    
    [NotNull]
    [DataType( DataType.DateTime )]
    [Required]
    public DateTime Birthday { get; set; }
}