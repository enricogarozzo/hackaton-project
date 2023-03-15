using hackatonBackEnd.Data;
using Microsoft.AspNetCore.Mvc;

namespace DefaultNamespace;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameRepository _repository;

    public GameController(IGameRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Game>>> GetGames()
    {
        return _repository.GetAll() == null
            ? NoContent()
            : new ActionResult<IEnumerable<Game>>(_repository.GetAll());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> GetGame(int id)
    {
        return _repository.GetOne(id) == null
            ? NoContent()
            : new ActionResult<Game>(_repository.GetOne(id));
    }
}