using DefaultNamespace;

namespace hackatonBackEnd.Data;

public class UserRepository : IUserRepository
{
    private readonly UserAnswerContext _context;
    
    public UserRepository(UserAnswerContext context)
    {
        _context = context;
    }


    public User GetOneUser(string name)
    {
        return _context.Users
                   .SingleOrDefault(user => user.Name == name) ??
               throw new InvalidOperationException("The user ${} was not found");
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public User CreateUser(UserRequest request)
    {
        int maxID = _context.Users.Max(user => user.Id);
        var newUser = new User
        {
            Id = maxID + 1,
            Name = request.Name,
            UserAnswers = new List<UserAnswer>()
        };
    
        _context.Users.Add(newUser);
        _context.SaveChanges();
        return newUser;
    }
}