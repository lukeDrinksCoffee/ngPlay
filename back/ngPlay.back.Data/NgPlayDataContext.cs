using PetaPoco;

namespace ngPlay.back.Data
{
    public class NgPlayDataContext : Database
    {
        public NgPlayDataContext()
            : base("ngPlayConnectionString")
        {
         
        }
    }
}
