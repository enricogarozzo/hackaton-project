using hackatonBackEnd.Data;
using Microsoft.AspNetCore.Mvc;

namespace DefaultNamespace;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;

    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return _repository.GetAllUsers() == null
            ? NoContent()
            : new ActionResult<IEnumerable<User>>(_repository.GetAllUsers());
    }
    
    [HttpGet("/{name}")]
    public async Task<ActionResult<User>> GetUser(string name)
    {
        return  _repository.GetOneUser(name) == null
            ? NoContent()
            : new ActionResult<User>(_repository.GetOneUser(name));
    }
    
    [HttpPost]
    public ActionResult<User> CreateUser(UserRequest request)
    {
        var newUser = _repository.CreateUser(request);
        return CreatedAtAction(nameof(GetUser), new { name = newUser.Name }, newUser);
    }
}