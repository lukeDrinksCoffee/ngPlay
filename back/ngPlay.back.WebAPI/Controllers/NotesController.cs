using ngPlay.back.Data.Entities;
using ngPlay.back.Domain.Contracts;
using ngPlay.back.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ngPlay.back.WebAPI.Controllers
{
    [Authorize]
    public class NotesController : ApiControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        /// <summary>
        /// Get the current users notes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NoteBindingModel> Get()
        {
            IEnumerable<Note> notes;
            var response = _noteService.GetNotesForUser(GetUserId(), out notes);

            ThrowIfNotOk(response);

            return notes.Select(NoteBindingModel.FromNote).ToList();
        }

        /// <summary>
        /// Delete a note
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            var response = _noteService.DeleteNote(id, GetUserId());

            return CheckServiceResponse(response);
        }

        /// <summary>
        /// Create a new note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public NoteBindingModel Post(NoteBindingModel note)
        {
            Note newNote;
            var response = _noteService.CreateNote(GetUserId(), note.Title, note.Content, out newNote);

            ThrowIfNotOk(response);

            note.Id = newNote.Id;

            return note;
        }

        /// <summary>
        /// Update a note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public IHttpActionResult Put(NoteBindingModel note)
        {
            var response = _noteService.UpdateNote(GetUserId(), note.ToNote());

            return CheckServiceResponse(response);
        }
    }
}
