using QuizApp.DataAccessLayer.Data;
using QuizApp.DataAccessLayer.Infrastructure.IRepository;
using QuizApp.Models;

namespace QuizApp.DataAccessLayer.Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async void Update(User user)
        {
            var _user = await _context.Users.FindAsync(user.Id);
            if (_user != null)
            {
                _user.Name = user.Name;
                _user.Email = user.Email;
                _user.UpdatedAt = DateTime.Now;
                _user.Password = user.Password;
                if (user.Image != null)
                {
                    _user.Image = user.Image;
                }
                if (user.Phone != null)
                {
                    _user.Phone = user.Phone;
                }

                if (user.InstituteId != null)
                {
                    _user.InstituteId = user.InstituteId;
                }
                if (user.Address != null)
                {
                    _user.Address = user.Address;
                }
                if (user.LevelId != null)
                {
                    _user.LevelId = user.LevelId;
                }

            }

        }
    }
}
