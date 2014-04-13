using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngPlay.back.Data.Entities
{
    [PetaPoco.PrimaryKey("UserID", autoIncrement = true)]
    public class User
    {
        public int UserID { get; set; }
        public String UserName { get; set; }
        public String PasswordHash { get; set; }
        public String Email { get; set; }
    }
}
