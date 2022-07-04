namespace QuizApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface IUnitOfWork
    {
        ILevelRepository Level { get; }
        ISubjectRepository Subject { get; }
        IQuestionRepository Question { get; }
        IQuizRepository Quiz { get; }
        IUserRepository User { get; }
        IResultRepository Result { get; }
        public void Save();
    }
}
