using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("send")]
        public async Task <IActionResult> Send()
        {
            return Ok();
        }
    }
}
