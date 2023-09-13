using Hangfire;
using hangfireJob.Services;
using Microsoft.AspNetCore.Mvc;
using static hangfireJob.Services.EmailService;

namespace hangfireJob.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class EmailController : ControllerBase
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly EmailService _emailService;

        public EmailController(IBackgroundJobClient backgroundJobClient, EmailService emailService)
        {
            _backgroundJobClient = backgroundJobClient;
            _emailService = emailService;
        }

        [HttpPost("send")]
        public IActionResult SendEmail([FromBody] EmailNotificationInput request)
        {
            // Enqueue a background job to send the email asynchronously
            _backgroundJobClient.Enqueue(() => _emailService.SendEmail(request.EmailAddress, request.Message));
            return Ok("Email will be sent asynchronously.");
        }
    }
}
