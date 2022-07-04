namespace QuizApp.Models
{
    public class Result
    {
        public long Id { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
        public Quiz Quiz { get; set; }
        public long QuizId { get; set; }
        public int Marks { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
