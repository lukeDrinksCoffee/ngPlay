using System;
using System.Web;
using System.Web.Http;

namespace ngPlay.back.WebAPI.Controllers
{
    public class EchoController : ApiController
    {
        // GET api/<controller>/5
        public object Get(string value)
        {
            // TODO LEO further investigate / generalise
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            return new
            {
                echo = String.Format("{0} : {1}", value, DateTime.Now)
            };
        }
    }
}