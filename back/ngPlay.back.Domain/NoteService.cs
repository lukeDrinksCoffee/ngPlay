using ngPlay.back.Data.Contracts;
using ngPlay.back.Data.Entities;
using ngPlay.back.Domain.Contracts;
using System.Collections.Generic;

namespace ngPlay.back.Domain
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public ServiceResponse GetNotesForUser(int userId, out IEnumerable<Note> notes)
        {
            notes = _noteRepository.GetNotesForUser(userId);

            return ServiceResponse.Ok;
        }

        ServiceResponse INoteService.DeleteNote(int noteId, int userId)
        {
            var note = _noteRepository.Get(noteId);

            if (note == null)
                return ServiceResponse.NotFound;

            if (note.UserId != userId)
                return ServiceResponse.NotAuthorised;

            _noteRepository.Delete(noteId);

            return ServiceResponse.Ok;
        }
    }
}
