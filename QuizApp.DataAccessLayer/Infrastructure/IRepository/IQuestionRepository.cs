using QuizApp.Models;

namespace QuizApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface IQuestionRepository : IRepository<Question>
    {
        public void Update(Question question);
    }
}
