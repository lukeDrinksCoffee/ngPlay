using ngPlay.back.Data.Entities;
using System.Collections.Generic;

namespace ngPlay.back.Domain.Contracts
{
    public interface INoteService
    {
        ServiceResponse GetNotesForUser(int userId, out IEnumerable<Note> notes);
        ServiceResponse CreateNote(int userId, string title, string content, out Note createdNote);
        ServiceResponse UpdateNote(int userId, Note modifiedNote);
        ServiceResponse DeleteNote(int noteId, int userId);
    }
}
