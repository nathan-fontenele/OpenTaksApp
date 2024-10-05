using Backend.Data;
using Backend.Model;

namespace Backend.Services;

public class UserService
{
    private UserRepository _userRepository;
    
    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public void AddUser(string firstname, string lastname, string email, string password)
    {
        var existingUser = _userRepository.GetUserByEmail(email);
        
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
        
        _userRepository.AddUser(firstname, lastname, email, passwordHash);
    }

    public List<UserModel> GetUsers()
    {
        return _userRepository.GetUsers();
    }
    
    public List<string> Login(string email, string password)
    {
        var user = _userRepository.Login(email);
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