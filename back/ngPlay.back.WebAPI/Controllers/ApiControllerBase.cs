using Microsoft.AspNet.Identity;
using ngPlay.back.Domain.Contracts;
using System;
using System.Net;
using System.Web.Http;

namespace ngPlay.back.WebAPI.Controllers
{
    public class ApiControllerBase : ApiController
    {
        protected int GetUserId()
        {
            int id;
            Int32.TryParse(User.Identity.GetUserId(), out id);

            return id;
        }

        protected IHttpActionResult CheckServiceResponse(ServiceResponse response)
        {
            switch (response)
            {
                case ServiceResponse.Error:
                    return InternalServerError();

                case ServiceResponse.NotAuthorised:
                    return Unauthorized();

                case ServiceResponse.NotFound:
                    return NotFound();

                default:
                    return Ok();
            }
        }

        protected void ThrowIfNotOk(ServiceResponse response)
        {
            switch (response)
            {
                case ServiceResponse.Error:
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);

                case ServiceResponse.NotAuthorised:
                    throw new HttpResponseException(HttpStatusCode.Unauthorized);

                case ServiceResponse.NotFound:
                    throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}