using QuizApp.DataAccessLayer.Data;
using QuizApp.DataAccessLayer.Infrastructure.IRepository;
using QuizApp.Models;

namespace QuizApp.DataAccessLayer.Infrastructure.Repository
{
    public class LevelRepository : Repository<Level>, ILevelRepository
    {
        private AppDbContext _context;
        public LevelRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async void Update(Level level)
        {
            var _level = await _context.Levels.FindAsync(level.Id);
            if (_level != null)
            {
                _level.Name = level.Name;
                _level.IsActive = level.IsActive;
                _level.UpdatedAt = DateTime.Now;

                if (level.Image != null)
                {
                    _level.Image = level.Image;
                }

                if (level.Icon != null)
                {
                    _level.Icon = level.Icon;
                }

            }

        }
    }
}
