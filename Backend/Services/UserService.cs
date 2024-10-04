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
        var existingUser = _userDAO.GetUserByEmail(email);
        
        if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname) ||
            string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Todos os campos são obrigatórios.");
        }

        if (existingUser)
        {
            throw new InvalidOperationException("O email já está em uso.");
        }
        
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        
        _userDAO.AddUser(firstname, lastname, email, passwordHash);
    }

    public List<UserModel> GetUsers()
    {
        return _userDAO.GetUsers();
    }
    
    public List<string> Login(string email, string password)
    {
        var user = _userDAO.Login(email);
        var userHash = user[3];
        
        if (user == null)
        {
            throw new InvalidOperationException("Usuário não encontrado.");
        }
        
        if (!BCrypt.Net.BCrypt.Verify(password, userHash))
        {
            throw new InvalidOperationException("Senha incorreta.");
        }
        
        return user;
    }
}