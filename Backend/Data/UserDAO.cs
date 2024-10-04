using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class UserDAO
{
    private AppDbContext _context;
    private UserModel _userModel;
    
    public UserDAO()
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
    
    public List<UserModel> GetUsers()
    {
        return _context.Users.ToList();
    }
}