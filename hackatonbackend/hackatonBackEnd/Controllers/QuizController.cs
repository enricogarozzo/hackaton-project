using Microsoft.AspNetCore.Mvc;

namespace DefaultNamespace;

[ApiController]
[Route("[controller]")]
public class QuizController : ControllerBase
{
    private readonly IQuizClient _quizClient;

    public QuizController(IQuizClient quizClient)
    {
        _quizClient = quizClient;
    }

    [HttpGet]
    public async Task<ActionResult<List<QuizResponse>>> GetQuizzes()
    {
        try
        {
            //this one gives me the quiz object from the HttpClient, the whole thing
            var rootApiObject = await _quizClient.GetQuizzesFromApi();
            var apiObjects = rootApiObject.Quizzes;

            // now I map the api response with my Model for the List
            var myQuizzesList =
                from apiObject in apiObjects
                select new QuizListResponse
                {
                    Quizzes = apiObjects
                };
            //and then I map my model for 1 item
            var myQuizList =
                from apiObject in apiObjects
                //from quiz in myQuizzesList if you include this line you get 10objects identical objects
                select new QuizResponse
                {
                    CorrectAnswer = apiObject.CorrectAnswer,
                    Question = apiObject.Question,
                    IncorrectAnswer1 = apiObject.IncorrectAnswers[0],
                    IncorrectAnswer2 = apiObject.IncorrectAnswers[1],
                    IncorrectAnswer3 = apiObject.IncorrectAnswers[2]
                };
            return myQuizList.ToList();
        }
        catch (Exception ex)
        {
            return NotFound(ex.ToString());
        }
    }
}