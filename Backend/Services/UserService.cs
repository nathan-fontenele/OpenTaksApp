using Backend.Data;
using Backend.Model;

namespace Backend.Services;

public class UserService
{
    private UserDAO _userDAO;
    
    public UserService(UserDAO userDAO)
    {
        _userDAO = userDAO ?? throw new ArgumentNullException(nameof(userDAO));
    }

    public void AddUser(string firstname, string lastname, string email, string password)
    {
        if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname) ||
            string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("All user details must be provided");
        }

        _userDAO.AddUser(firstname, lastname, email, password);
    }

    public List<UserModel> GetUsers()
    {
        return _userDAO.GetUsers();
    }
}