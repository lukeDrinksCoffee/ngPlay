using ngPlay.back.Data.Contracts;
using ngPlay.back.Data.Entities;

namespace ngPlay.back.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly NgPlayDataContext _dataContext;

        public UserRepository(NgPlayDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Insert(User user)
        {
            return (int)_dataContext.Insert(user);
        }

        public User Get(int id)
        {
            return _dataContext.SingleOrDefault<User>(id);
        }

        public User GetByName(string name)
        {
            return _dataContext.SingleOrDefault<User>("SELECT * FROM [User] WHERE UserName = @0", name);
        }

        public User GetByEmail(string email)
        {
            return _dataContext.SingleOrDefault<User>("SELECT * FROM [User] WHERE Email = @0", email);
        }

        public int Update(User user)
        {
            return _dataContext.Update(user);
        }

        public int UpdatePasswordHash(User user)
        {
            return _dataContext.Update(user, new[] {"PasswordHash"});
        }

        public int Delete(User user)
        {
            return _dataContext.Delete(user);
        }
    }
}
