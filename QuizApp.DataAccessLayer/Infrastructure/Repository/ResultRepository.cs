using QuizApp.DataAccessLayer.Data;
using QuizApp.DataAccessLayer.Infrastructure.IRepository;
using QuizApp.Models;

namespace QuizApp.DataAccessLayer.Infrastructure.Repository
{
    public class ResultRepository : Repository<Result>, IResultRepository
    {
        private AppDbContext _context;
        public ResultRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async void Update(Result result)
        {
            var _result = await _context.Results.FindAsync(result.Id);
            if (_result != null)
            {
                _result.Marks = result.Marks;
                _result.UpdatedAt = DateTime.Now;
            }

        }
    }
}
