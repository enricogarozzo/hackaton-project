using System.Text.Json.Serialization;

namespace DefaultNamespace;

public class QuizList
{
    [JsonPropertyName("results")] public List<Quiz> Quizzes { get; set; }
}