using QuizApp.DataAccessLayer.Data;
using QuizApp.DataAccessLayer.Infrastructure.IRepository;
using QuizApp.Models;

namespace QuizApp.DataAccessLayer.Infrastructure.Repository
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        private AppDbContext _context;
        public SubjectRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async void Update(Subject subject)
        {
            var _subject = await _context.Subjects.FindAsync(subject.Id);
            if (_subject != null)
            {
                _subject.Name = subject.Name;
                _subject.IsActive = subject.IsActive;
                _subject.UpdatedAt = DateTime.Now;
                if (subject.Image != null)
                {
                    _subject.Image = subject.Image;
                }

                if (subject.Icon != null)
                {
                    _subject.Icon = subject.Icon;
                }
                if (subject.LevelId != null)
                {
                    _subject.LevelId = subject.LevelId;
                }

            }

        }
    }
}
