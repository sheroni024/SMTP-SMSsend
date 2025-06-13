using Microsoft.AspNetCore.Mvc;
using SMTPsendEmail.Services;

namespace SMTPsendEmail.Controllers
{
    public class EmailController : Controller
    {
        private readonly EmailService _emailService;
        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet, Route("Email")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(string toEmail, string subject, string message)
        {
            _emailService.SendEmail(toEmail, subject, message);
            ViewBag.Message = "Email sent successfully!";
            return View("Index");
        }
    }
}
