using System;
using System.Web;
using System.Web.Http;
using ngPlay.back.Domain.Contracts;
using ngPlay.back.Domain.Entities;

namespace ngPlay.back.WebAPI.Controllers
{
    public class EchoController : ApiController
    {
        private readonly IAppLogService _service;

        public EchoController(IAppLogService service)
        {
            _service = service;
        }

        // GET api/<controller>/5
        public object Get(string value)
        {
            var now = DateTime.Now;

            _service.Add(new AppLogEntry
            {
                TimeStamp = now,
                Detail = "Ping received"
            });

            // TODO LEO further investigate / generalise
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            return new
            {
                echo = String.Format("{0} : {1}", value, now)
            };
        }
    }
}