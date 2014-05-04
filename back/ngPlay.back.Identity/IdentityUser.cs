using AutoMapper;
using Microsoft.AspNet.Identity;
using ngPlay.back.Data.Entities;
using System;

namespace ngPlay.back.Identity
{
    public class IdentityUser : IUser<string>
    {
        public String Id { get; private set; }
        public String Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public String PasswordHash { get; set; }
        public String SecurityStamp { get; set; }
        public String PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public String UserName { get; set; }

        public User ToUser()
        {
            return Mapper.Map<IdentityUser, User>(this);
        }

        public virtual void PopulateFromUser(User user)
        {
            Mapper.Map(user, this);
        }

        public static IdentityUser FromUser(User user)
        {
            return Mapper.Map<User, IdentityUser>(user);
        }

        static IdentityUser()
        {
            Mapper.CreateMap<User, IdentityUser>().
                ForMember(iu => iu.Id, m => m.MapFrom(u => u.UserId.ToString()));

            Mapper.CreateMap<IdentityUser, User>().
                ForMember(u => u.UserId, m => m.MapFrom(iu => Convert.ToInt32(iu.Id)));
        }
    }
}
