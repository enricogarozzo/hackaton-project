using DefaultNamespace;

namespace hackatonBackEnd.Data;

public interface IUserAnswerRepository
{
    public UserAnswer GetOneAnswer(string question);

    public IEnumerable<UserAnswer> GetAllAnswers();

    public UserAnswer CreateAnswer(UserAnswerRequest request);
}