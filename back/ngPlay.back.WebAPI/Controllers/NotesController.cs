using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using ngPlay.back.Domain.Contracts;
using ngPlay.back.WebAPI.Models;

namespace ngPlay.back.WebAPI.Controllers
{
    [Authorize]
    public class NotesController : ApiController
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

            var notes = _noteService.GetNotesForUser(id);

            return notes.Select(n => new NoteBindingModel
                                     {
                                         NoteId = n.NoteId,
                                         Title = n.Title,
                                         Content = n.Content
                                     })
                        .ToList();
        }
    }
}
