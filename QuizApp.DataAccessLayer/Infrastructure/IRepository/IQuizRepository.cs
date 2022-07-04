using QuizApp.Models;

namespace QuizApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface IQuizRepository : IRepository<Quiz>
    {
        public void Update(Quiz quiz);
    }
}
