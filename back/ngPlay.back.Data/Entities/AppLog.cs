using System;

namespace ngPlay.back.Data.Entities
{
    [PetaPoco.PrimaryKey("Id", autoIncrement = true)]
    public class AppLog
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public String Detail { get; set; }
    }
}
