using ngPlay.back.Data.Entities;
using System.Collections.Generic;

namespace ngPlay.back.Data.Contracts
{
    public interface INoteRepository
    {
        Note Get(int id);
        IEnumerable<Note> GetNotesForUser(int userId);
        void Delete(int id);
    }
}
