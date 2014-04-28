using Microsoft.AspNet.Identity;
using ngPlay.back.Data.Entities;
using ngPlay.back.Domain.Contracts;
using ngPlay.back.WebAPI.Models;
using System;
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

        // GET api/values
        public IEnumerable<object> Get()
        {
            int id;
            Int32.TryParse(User.Identity.GetUserId(), out id);

            IEnumerable<Note> notes;
            var response = _noteService.GetNotesForUser(id, out notes);

            ThrowIfNotOk(response);

            return notes.Select(n => new NoteBindingModel
                                     {
                                         Id = n.Id,
                                         Title = n.Title,
                                         Content = n.Content
                                     })
                        .ToList();
        }

        public IHttpActionResult Delete(int id)
        {
            var response = _noteService.DeleteNote(id, GetUserId());

            return CheckServiceResponse(response);
        }
    }
}
