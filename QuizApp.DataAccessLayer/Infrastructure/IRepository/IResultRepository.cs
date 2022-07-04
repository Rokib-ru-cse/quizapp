using QuizApp.Models;

namespace QuizApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface IResultRepository : IRepository<Result>
    {
        public void Update(Result result);
    }
}
