using System.Net.Http.Headers;
using System.Text.Json;

namespace DefaultNamespace;

public class QuizClient : IQuizClient
{
    public async Task<QuizList> GetQuizzesFromApi()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var url = "https://opentdb.com/api.php?amount=10&category=22&difficulty=easy&type=multiple";
        var quizzesTask = client.GetStreamAsync(url);

        return await JsonSerializer.DeserializeAsync<QuizList>(await quizzesTask);
    }
}