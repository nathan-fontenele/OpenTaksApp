using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class UserRepository
{
    private AppDbContext _context;
    private UserModel _userModel;
    
    public UserRepository()
    {
        _context = new AppDbContext(new DbContextOptions<AppDbContext>());
        _userModel = new UserModel();
    }
    
    public void AddUser(string firstname, string lastname, string email, string password)
    {
        _userModel.FirstName = firstname;
        _userModel.LastName = lastname;
        _userModel.Email = email;
        _userModel.Password = password;
        _context.Users.Add(_userModel);
        _context.SaveChanges();
    }
    
    public bool GetUserByEmail(string email)
    {
        bool existingUser = _context.Users.Any(u => u.Email == email);
        
        if (existingUser)
        {
            return true;
        }
        else{
            return false;
        }
    }
    
    public List<string> Login(string email)
    {
        var userProperties = _context.Users
            .Where(u => u.Email == email)
            .Select(u => new List<string>{u.FirstName, u.LastName, u.Email})
            .FirstOrDefault();
        
        return userProperties;
    }
    
    public List<UserModel> GetUsers()
    {
        return _context.Users.ToList();
    }
}