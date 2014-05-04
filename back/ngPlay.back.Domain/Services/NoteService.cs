using System.Collections.Generic;
using ngPlay.back.Data.Contracts;
using ngPlay.back.Data.Entities;
using ngPlay.back.Domain.Contracts;

namespace ngPlay.back.Domain.Services
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

        public ServiceResponse CreateNote(int userId, string title, string content, out Note createdNote)
        {
            var note = new Note { UserId = userId, Title = title, Content = content };

            _noteRepository.Create(note);

            createdNote = note;

            return ServiceResponse.Ok;
        }

        public ServiceResponse UpdateNote(int userId, Note modifiedNote)
        {
            if (modifiedNote == null)
                return ServiceResponse.Error;

            var existingNote = _noteRepository.Get(modifiedNote.Id);

            if (existingNote == null)
                return ServiceResponse.NotFound;

            if (existingNote.UserId != userId)
                return ServiceResponse.NotAuthorised;

            modifiedNote.UserId = userId;

            _noteRepository.Update(modifiedNote);

            return ServiceResponse.Ok;
        }

        public ServiceResponse DeleteNote(int noteId, int userId)
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
