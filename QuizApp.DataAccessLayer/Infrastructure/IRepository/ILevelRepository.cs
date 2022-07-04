using QuizApp.Models;

namespace QuizApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface ILevelRepository : IRepository<Level>
    {
        public void Update(Level level);
    }
}
