using QuizApp.DataAccessLayer.Data;
using QuizApp.DataAccessLayer.Infrastructure.IRepository;
using QuizApp.Models;

namespace QuizApp.DataAccessLayer.Infrastructure.Repository
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly AppDbContext _context;
        public QuestionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async void Update(Question question)
        {
            var _question = await _context.Questions.FindAsync(question.Id);
            if (_question != null)
            {
                _question.Title = question.Title;
                _question.IsActive = question.IsActive;
                _question.IsRadio = question.IsRadio;
                _question.UpdatedAt = DateTime.Now;
                _question.SubjectId = question.SubjectId;
                _question.Option1 = question.Option1;
                _question.Option2 = question.Option2;
                _question.Answer = question.Answer;

                if (question.Image != null)
                {
                    _question.Image = question.Image;
                }

                if (question.Description != null)
                {
                    _question.Description = question.Description;
                }
                if (question.LevelId != null)
                {
                    _question.LevelId = question.LevelId;
                }

                if (_question.Option3 != null)
                {
                    _question.Option3 = question.Option3;
                }
                if (_question.Option4 != null)
                {
                    _question.Option4 = question.Option4;
                }
                if (_question.Option5 != null)
                {
                    _question.Option5 = question.Option5;
                }
                if (_question.Option6 != null)
                {
                    _question.Option6 = question.Option6;
                }
            }

        }

    }
}
