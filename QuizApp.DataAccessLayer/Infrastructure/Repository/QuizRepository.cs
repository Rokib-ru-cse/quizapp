using QuizApp.DataAccessLayer.Data;
using QuizApp.DataAccessLayer.Infrastructure.IRepository;
using QuizApp.Models;

namespace QuizApp.DataAccessLayer.Infrastructure.Repository
{
    public class QuizRepository : Repository<Quiz>, IQuizRepository
    {
        private AppDbContext _context;
        public QuizRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async void Update(Quiz quiz)
        {
            var _quiz = await _context.Quizzes.FindAsync(quiz.Id);
            if (_quiz != null)
            {

                _quiz.Title = quiz.Title;
                _quiz.IsActive = quiz.IsActive;
                _quiz.Marks = quiz.Marks;
                _quiz.UpdatedAt = DateTime.Now;

                if (quiz.Image != null)
                {
                    _quiz.Image = quiz.Image;
                }

                if (quiz.Icon != null)
                {
                    _quiz.Icon = quiz.Icon;
                }
                if (quiz.Duration != null)
                {
                    _quiz.Duration = quiz.Duration;
                }
            }

        }
    }
}
