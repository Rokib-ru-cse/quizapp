using QuizApp.Models;

namespace QuizApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        public void Update(Subject subject);
    }
}
