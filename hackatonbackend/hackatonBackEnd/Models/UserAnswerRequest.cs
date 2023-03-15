namespace DefaultNamespace;

public class UserAnswerRequest
{
    public string Question { get; set; }

    public string CorrectAnswer { get; set; }

    public string GivenAnswer { get; set; }
    
    public bool Correct { get; set; }

    public int UserId { get; set; }
}