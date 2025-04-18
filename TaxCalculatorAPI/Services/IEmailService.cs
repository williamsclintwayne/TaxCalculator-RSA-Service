using System.Threading.Tasks;
namespace TaxCalculatorAPI.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmailWithAttachmentAsync(string toEmail, string subject, string body, byte[] attachmentBytes, string attachmentName);
    }
}
