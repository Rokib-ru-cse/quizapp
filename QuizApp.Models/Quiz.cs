using Microsoft.EntityFrameworkCore;

namespace QuizApp.Models
{
    [Index(nameof(CreatedById), IsUnique = false), Index(nameof(UpdatedById), IsUnique = false)]
    public class Quiz
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Image { get; set; }
        public string? Icon { get; set; }
        public bool IsActive { get; set; } = true;
        public int Marks { get; set; }
        public DateTime? Duration { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public virtual User CreatedBy { get; set; }
        public string CreatedById { get; set; }
        public virtual User UpdatedBy { get; set; }
        public string UpdatedById { get; set; }
        public ICollection<Question> Questions { get; set; }

    }
}
