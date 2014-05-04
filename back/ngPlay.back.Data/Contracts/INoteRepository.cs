using ngPlay.back.Data.Entities;
using System.Collections.Generic;

namespace ngPlay.back.Data.Contracts
{
    public interface INoteRepository
    {
        Note Get(int id);
        IEnumerable<Note> GetNotesForUser(int userId);
        void Create(Note note);
        void Update(Note note);
        void Delete(int id);
    }
}
