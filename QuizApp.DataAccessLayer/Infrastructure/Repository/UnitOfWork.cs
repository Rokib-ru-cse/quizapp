using QuizApp.DataAccessLayer.Data;
using QuizApp.DataAccessLayer.Infrastructure.IRepository;

namespace QuizApp.DataAccessLayer.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private AppDbContext _context;
        public ILevelRepository Level { get; private set; }

        public ISubjectRepository Subject { get; private set; }

        public IQuestionRepository Question { get; private set; }

        public IQuizRepository Quiz { get; private set; }

        public IUserRepository User { get; private set; }

        public IResultRepository Result { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Level = new LevelRepository(context);
            Subject = new SubjectRepository(context);
            Question = new QuestionRepository(context);
            Quiz = new QuizRepository(context);
            User = new UserRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
