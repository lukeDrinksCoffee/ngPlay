using ngPlay.back.Data.Contracts;
using ngPlay.back.Data.Entities;
using ngPlay.back.Domain.Contracts;

namespace ngPlay.back.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool IsUserNameUnique(string name)
        {
            return _repository.GetByName(name) == null;
        }

        public bool IsEmailUnique(string email)
        {
            return _repository.GetByEmail(email) == null;
        }

        public User GetUser(int id)
        {
            return _repository.Get(id);
        }
    }
}
