using ngPlay.back.Data.Entities;
using System.Collections.Generic;

namespace ngPlay.back.Data.Contracts
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetNotesForUser(int userId);
    }
}
