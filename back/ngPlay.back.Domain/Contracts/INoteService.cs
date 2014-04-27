using ngPlay.back.Data.Entities;
using System.Collections.Generic;

namespace ngPlay.back.Domain.Contracts
{
    public interface INoteService
    {
        IEnumerable<Note> GetNotesForUser(int userId);
    }
}
