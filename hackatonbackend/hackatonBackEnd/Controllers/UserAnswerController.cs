using hackatonBackEnd.Data;
using Microsoft.AspNetCore.Mvc;

namespace DefaultNamespace;

[ApiController]
[Route("[controller]")]
public class UserAnswerController : ControllerBase
{
    private readonly IUserAnswerRepository _repository;

    public UserAnswerController(IUserAnswerRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserAnswer>>> GetAnswers()
    {
        return _repository.GetAllAnswers() == null
            ? NoContent()
            : new ActionResult<IEnumerable<UserAnswer>>(_repository.GetAllAnswers());
    }

    [HttpGet("{question}")]
    public async Task<ActionResult<UserAnswer>> GetAnswer(string question)
    {
        return  _repository.GetOneAnswer(question) == null
            ? NoContent()
            : new ActionResult<UserAnswer>(_repository.GetOneAnswer(question));
    }

    [HttpPost]
    public ActionResult<UserAnswer> CreateNewAnswer(UserAnswerRequest request)
    {
        var newAnswer = _repository.CreateAnswer(request);
        return CreatedAtAction(nameof(GetAnswer), new { question = newAnswer.Question }, newAnswer);
    }
}