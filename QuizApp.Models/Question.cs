using Microsoft.EntityFrameworkCore;

namespace QuizApp.Models
{
    [Index(nameof(CreatedById), IsUnique = false), Index(nameof(UpdatedById), IsUnique = false)]
    public class Question
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsRadio { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;



        public virtual User? CreatedBy { get; set; }
        public string CreatedById { get; set; }
        public virtual User? UpdatedBy { get; set; }
        public string UpdatedById { get; set; }



        public Level? Level { get; set; }
        public long? LevelId { get; set; }
        public Subject? Subject { get; set; }

        public long SubjectId { get; set; }

        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string? Option3 { get; set; }
        public string? Option4 { get; set; }
        public string? Option5 { get; set; }
        public string? Option6 { get; set; }
        public string Answer { get; set; }
        public ICollection<Quiz>? Quizzes { get; set; }
    }
}
