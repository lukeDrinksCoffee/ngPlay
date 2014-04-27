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

        public IEnumerable<Note> GetNotesForUser(int userId)
        {
            return _noteRepository.GetNotesForUser(userId);
        }
    }
}
