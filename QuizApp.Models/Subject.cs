namespace QuizApp.Models
{
    public class Subject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Icon { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Level? Level { get; set; }
        public long? LevelId { get; set; }

        public IEnumerable<Question>? Questions { get; set; }

    }
}
