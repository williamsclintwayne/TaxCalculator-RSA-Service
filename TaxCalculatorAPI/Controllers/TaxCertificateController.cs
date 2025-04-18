using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxCalculatorAPI.Documents;
using TaxCalculatorAPI.Services.Models;
using TaxCalculatorAPI.Services;
using QuestPDF.Fluent;

namespace TaxCalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxCertificateController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public TaxCertificateController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("generate-pdf")]
        public IActionResult GeneratePdf([FromBody] TaxCertificateData data)
        {
            var document = new TaxCertificateDocument(data);
            var pdfBytes = document.GeneratePdf();

            return File(pdfBytes, "application/pdf", $"{data.FullName.Replace(" ", "_")}_TaxCertificate_{data.TaxYear}.pdf");
        }

        public class EmailRequest
        {
            public string Email { get; set; }
            public string PdfBase64 { get; set; }
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.PdfBase64))
                return BadRequest("Email and PDF content are required.");

            var pdfBytes = Convert.FromBase64String(request.PdfBase64);

            var success = await _emailService.SendEmailWithAttachmentAsync(
                request.Email,
                "Your South African Tax Certificate",
                "Please find attached your tax certificate.",
                pdfBytes,
                "TaxCertificate.pdf"
            );

            if (success)
                return Ok("Email sent successfully.");
            else
                return StatusCode(500, "Failed to send email.");
        }
    }
}
