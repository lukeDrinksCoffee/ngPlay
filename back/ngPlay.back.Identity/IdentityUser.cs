using Microsoft.AspNet.Identity;
using ngPlay.back.Data.Entities;
using System;

namespace ngPlay.back.Identity
{
    public class IdentityUser : IUser<string>
    {
        public String Id { get; private set; }
        public String UserName { get; set; }
        public String PasswordHash { get; set; }
        public String Email { get; set; }

        public User ToUser()
        {
            return new User
            {
                UserID = Convert.ToInt32(Id),
                UserName = UserName,
                PasswordHash = PasswordHash,
                Email = Email
            };
        }

        public static IdentityUser FromUser(User user)
        {
            return new IdentityUser
            {
                Id = user.UserID.ToString(),
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email
            };
        }
    }
}
