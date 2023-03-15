using DefaultNamespace;

namespace hackatonBackEnd.Data;

public class GameRepository : IGameRepository
{
    private readonly UserAnswerContext _context;
    
    public GameRepository(UserAnswerContext context)
    {
        _context = context;
    }
    

    public Game GetOne(int id)
    {
        return _context.Games
                   .SingleOrDefault(game => game.UserId == id) ??
               throw new InvalidOperationException("The question was not found");
    }

    public IEnumerable<Game> GetAll()
    {
        return _context.Games.ToList();
    }
}