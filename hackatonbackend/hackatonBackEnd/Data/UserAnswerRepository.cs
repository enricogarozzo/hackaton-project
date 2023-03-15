using DefaultNamespace;

namespace hackatonBackEnd.Data;

public class UserAnswerRepository : IUserAnswerRepository
{
    private readonly UserAnswerContext _context;
    
    public UserAnswerRepository(UserAnswerContext context)
    {
        _context = context;
    }

    public UserAnswer GetOneAnswer(string question)
    {
        return _context.UserAnswers
                   .SingleOrDefault(answer => answer.Question == question) ??
               throw new InvalidOperationException("The question was not found");
    }

    public IEnumerable<UserAnswer> GetAllAnswers()
    {
        return _context.UserAnswers.ToList();
    }

    public UserAnswer CreateAnswer(UserAnswerRequest request)
    {
        var answer = new UserAnswer
        {
            UserId = 1,
            Question = request.Question,
            CorrectAnswer = request.CorrectAnswer,
            GivenAnswer = request.GivenAnswer,
            Correct = request.CorrectAnswer == request.GivenAnswer
        };
    
        _context.UserAnswers.Add(answer);
        _context.SaveChanges();
        return answer;
    }
    
}

//dotnet aspnet-codegenerator controller -name UserAnswerNewController -m UserAnswer -dc UserAnswerContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --restWithNoViews
