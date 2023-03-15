namespace DefaultNamespace;

public class Game
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public int Score { get; set; }
    
    public DateTime PlayedOn { get; set; }
    
    public virtual ICollection<UserAnswer> UserAnswers { get; set; }
}