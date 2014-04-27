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

        public IEnumerable<Note> GetNotesForUser(int userId)
        {
            return _dataContext.Query<Note>("SELECT * FROM [Note] WHERE UserId = @0", userId);
        }
    }
}
