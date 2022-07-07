
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class User
    {

        public string? Id { get; set; }
        [Required, MinLength(2, ErrorMessage = "Minimum length 2")]
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Minlength is 4")]
        public string Password { get; set; }
        public string? Image { get; set; }
        public string? Phone { get; set; }

        public Institute? Institute { get; set; }
        public long? InstituteId { get; set; }
        public string? Address { get; set; }
        public Level? Level { get; set; }
        public long? LevelId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<Question>? Questions { get; set; }
        public virtual ICollection<Quiz>? Quizzes { get; set; }

    }
}
