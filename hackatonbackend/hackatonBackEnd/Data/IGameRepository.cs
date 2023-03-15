using DefaultNamespace;

namespace hackatonBackEnd.Data;

public interface IGameRepository
{
        public Game GetOne(int id);
        
        public IEnumerable<Game> GetAll();
     
}