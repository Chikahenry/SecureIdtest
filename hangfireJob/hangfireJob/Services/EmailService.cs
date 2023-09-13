using Microsoft.Extensions.Options;

namespace hangfireJob.Services
{
    public class EmailService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private string _contentRootPath = string.Empty;

        public EmailService( IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }
        public string GetTemplatePath(string fileName)
        {
            _contentRootPath = _webHostEnvironment.ContentRootPath;
            var path = Path.Combine(_contentRootPath, "EmailTemplates", fileName);

            return path;
        }
        public static class ClientRoutes
        {
            public const string LocalBaseUrl = "https://localhost:7065";
            public const string StagingBaseUrl = "https://api-staging.ng";
            public const string ProdBaseUrl = "";


        }
        public class EmailNotificationInput
        {
            public string EmailAddress { set; get; } = default!;
            public string Subject { set; get; } = string.Empty;
            public string Message { set; get; } = string.Empty;
            public string SenderEmail { set; get; } = string.Empty;
        }
        public void SendEmail(string emailAddress, string message)
        {
            // Simulate sending an email (replace with your actual email sending logic)
            Console.WriteLine($"Sending email to {emailAddress}: {message}");
            // Throw an exception to simulate a failure
            // handles automatic retries by default
            throw new Exception("Email sending failed");
        }
    }
}
