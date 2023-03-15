namespace DefaultNamespace;

public interface IQuizClient
{
    public Task<QuizList> GetQuizzesFromApi();
}