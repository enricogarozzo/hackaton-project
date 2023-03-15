using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DefaultNamespace;

public class UserAnswer
{
    
    public int Id { get; set; }
    public string Question { get; set; }
    public string CorrectAnswer { get; set; }
    public string GivenAnswer { get; set; }
    public bool Correct { get; set; }
    public int UserId { get; set; }
}