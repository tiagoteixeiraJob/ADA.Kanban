using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidateExceptionController : ControllerBase
    {
        [HttpPost]
        [Route("/errors")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult PostErrors()
        {
            var contextException = HttpContext.Features.Get<IExceptionHandlerFeature>();

            var responseStatusCode = contextException.Error.GetType().Name switch
            {
                "NullReferenceException" => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.ServiceUnavailable
            };

            return Problem(detail: contextException.Error.Message, statusCode: (int)responseStatusCode);
        }

        [HttpPut]
        [Route("/errors")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult PutErrors()
        {
            var contextException = HttpContext.Features.Get<IExceptionHandlerFeature>();

            var responseStatusCode = contextException.Error.GetType().Name switch
            {
                "NullReferenceException" => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.ServiceUnavailable
            };

            return Problem(detail: contextException.Error.Message, statusCode: (int)responseStatusCode);
        }
    }
}
