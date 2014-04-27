
namespace ngPlay.back.Data.Entities
{
    [PetaPoco.PrimaryKey("NoteId", autoIncrement = true)]
    public class Note
    {
        public int NoteId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
