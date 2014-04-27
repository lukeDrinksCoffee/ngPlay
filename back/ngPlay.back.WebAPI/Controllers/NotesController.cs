using System.Collections.Generic;
using System.Web.Http;

namespace ngPlay.back.WebAPI.Controllers
{
    [Authorize]
    public class NotesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
