using ngPlay.back.Data.Contracts;
using ngPlay.back.Data.Entities;
using ngPlay.back.Domain.Contracts;

namespace ngPlay.back.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsUserNameUnique(string name)
        {
            return _userRepository.GetByName(name) == null;
        }

        public bool IsEmailUnique(string email)
        {
            return _userRepository.GetByEmail(email) == null;
        }

        public User GetUser(int id)
        {
            return _userRepository.Get(id);
        }
    }
}
