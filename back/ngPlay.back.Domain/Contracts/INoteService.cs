using ngPlay.back.Data.Entities;
using System.Collections.Generic;

namespace ngPlay.back.Domain.Contracts
{
    public interface INoteService
    {
        ServiceResponse GetNotesForUser(int userId, out IEnumerable<Note> notes);
        ServiceResponse DeleteNote(int noteId, int userId);
    }
}
