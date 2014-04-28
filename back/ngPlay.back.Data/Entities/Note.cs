
namespace ngPlay.back.Data.Entities
{
    [PetaPoco.PrimaryKey("Id", autoIncrement = true)]
    public class Note
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
