using System.Text.Json.Serialization;

namespace DefaultNamespace;

public class Quiz
{
    [JsonPropertyName("question")] public string Question { get; set; }

    [JsonPropertyName("correct_answer")] public string CorrectAnswer { get; set; }

    [JsonPropertyName("incorrect_answers")]

    public string[] IncorrectAnswers { get; set; }
}