using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Ratbags.Emails.API.Controllers
{
    [ApiController]
    [Route("api/emails")]
    public class EmailsController : ControllerBase
    {
        private readonly ILogger<EmailsController> _logger;

        public EmailsController(ILogger<EmailsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        [SwaggerOperation(Summary = "Sends an email",
        Description = "Not working yet but useful for calls direct from ui")]
        [HttpPost("send")]
        public async Task <IActionResult> Send()
        {
            return Ok();
        }
    }
}
