using System;

namespace ngPlay.back.Data.Entities
{
    [PetaPoco.PrimaryKey("UserID", autoIncrement = true)]
    public class User
    {
        public int UserID { get; set; }
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
    }
}
