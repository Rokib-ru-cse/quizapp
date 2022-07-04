using QuizApp.Models;

namespace QuizApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        public void Update(User user);
    }
}
