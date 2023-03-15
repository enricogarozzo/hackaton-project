using DefaultNamespace;

namespace hackatonBackEnd.Data;

public interface IUserRepository
{
    public User GetOneUser(string name);
    public IEnumerable<User> GetAllUsers();
    public User CreateUser(UserRequest request);
}