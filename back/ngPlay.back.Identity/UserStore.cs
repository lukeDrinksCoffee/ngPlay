using Microsoft.AspNet.Identity;
using ngPlay.back.Data.Contracts;
using System;
using System.Threading.Tasks;


namespace ngPlay.back.Identity
{
    public class UserStore<TUser> : IUserStore<TUser>, IUserPasswordStore<TUser>, IUserEmailStore<TUser> where TUser : IdentityUser, new()
    {
        private readonly IUserRepository _userRepository;

        public UserStore(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Dispose()
        {
            // TODO LEO investigate and implement
        }

        public Task CreateAsync(TUser user)
        {
            var identUser = user as IdentityUser;

            _userRepository.Insert(identUser.ToUser());

            return Task.FromResult(0);
        }

        public Task UpdateAsync(TUser user)
        {
            var identUser = user as IdentityUser;

            _userRepository.Update(identUser.ToUser());

            return Task.FromResult(0);
        }

        public Task DeleteAsync(TUser user)
        {
            var identUser = user as IdentityUser;

            _userRepository.Delete(identUser.ToUser());

            return Task.FromResult(0);
        }

        public Task<TUser> FindByIdAsync(string userId)
        {
            var id = Convert.ToInt32(userId);

            if (id < 1)
                return Task.FromResult<TUser>(null);

            var user = _userRepository.Get(id);
            if (user == null)
                return Task.FromResult<TUser>(null);

            var tUser = new TUser();
            tUser.PopulateFromUser(user);

            return Task.FromResult(tUser);
        }

        public Task<TUser> FindByNameAsync(string userName)
        {
            if (String.IsNullOrEmpty(userName))
                return Task.FromResult<TUser>(null);

            var user = _userRepository.GetByName(userName);
            if (user == null)
                return Task.FromResult<TUser>(null);

            var tUser = new TUser();
            tUser.PopulateFromUser(user);

            return Task.FromResult(tUser);
        }

        public Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;

            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(TUser user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(TUser user)
        {
            return Task.FromResult(!String.IsNullOrEmpty(user.PasswordHash));
        }

        public Task SetEmailAsync(TUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(TUser user)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(TUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task<TUser> FindByEmailAsync(string email)
        {
            if (String.IsNullOrEmpty(email))
                return Task.FromResult<TUser>(null);

            var user = _userRepository.GetByEmail(email);
            if (user == null)
                return Task.FromResult<TUser>(null);

            var tUser = new TUser();
            tUser.PopulateFromUser(user);

            return Task.FromResult(tUser);
        }
    }
}
