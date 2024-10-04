namespace Backend.Services;

public class UserService
{
    private List<string> _users = new();

    public void AddUser(string userName)
    {
        _users.Add(userName);
    }

    public List<string> GetUsers()
    {
        return _users;
    }
}