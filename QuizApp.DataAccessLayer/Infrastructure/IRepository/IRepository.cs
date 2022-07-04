using System.Linq.Expressions;

namespace QuizApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T GetT(Expression<Func<T, bool>> predicate);
        public void Add(T entity);
        public void Delete(T entity);
        public void DeleteRange(IEnumerable<T> entity);
    }
}
