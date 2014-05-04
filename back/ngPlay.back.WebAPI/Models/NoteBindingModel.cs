
using ngPlay.back.Data.Entities;

namespace ngPlay.back.WebAPI.Models
{
    public class NoteBindingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public NoteBindingModel() { }

        public NoteBindingModel(Note note)
        {
            Id = note.Id;
            Title = note.Title;
            Content = note.Content;
        }

        public static NoteBindingModel FromNote(Note note)
        {
            return new NoteBindingModel(note);
        }

        public Note ToNote()
        {
            return new Note
                   {
                       Id = Id,
                       Title = Title,
                       Content = Content
                   };
        }
    }
}