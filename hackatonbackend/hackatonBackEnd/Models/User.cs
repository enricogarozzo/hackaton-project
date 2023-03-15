using System.ComponentModel.DataAnnotations;

namespace DefaultNamespace;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    
    public virtual ICollection<Game> Games { get; set; }
}

