using ngPlay.back.Data.Contracts;
using ngPlay.back.Data.Entities;
using System.Collections.Generic;

namespace ngPlay.back.Data
{
    public class NoteRepository : INoteRepository
    {
        private readonly NgPlayDataContext _dataContext;

        public NoteRepository(NgPlayDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Note Get(int id)
        {
            return _dataContext.SingleOrDefault<Note>(id);
        }

        public IEnumerable<Note> GetNotesForUser(int userId)
        {
            return _dataContext.Query<Note>("SELECT * FROM [Note] WHERE UserId = @0", userId);
        }

        public void Create(Note note)
        {
            _dataContext.Insert(note);
        }

        public void Update(Note note)
        {
            _dataContext.Update(note);
        }

        public void Delete(int id)
        {
            _dataContext.Delete<Note>(id);
        }
    }
}
