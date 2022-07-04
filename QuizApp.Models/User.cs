
namespace QuizApp.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
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
