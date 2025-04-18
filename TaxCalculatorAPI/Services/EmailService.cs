using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System.Threading.Tasks;

namespace TaxCalculatorAPI.Services
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendEmailWithAttachmentAsync(string toEmail, string subject, string body, byte[] attachmentBytes, string attachmentName)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Tax Calculator", "no-reply@yourdomain.com"));
                message.To.Add(MailboxAddress.Parse(toEmail));
                message.Subject = subject;

                var builder = new BodyBuilder { TextBody = body };
                builder.Attachments.Add(attachmentName, attachmentBytes);
                message.Body = builder.ToMessageBody();

                using var client = new SmtpClient();
                await client.ConnectAsync("smtp.yourprovider.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("smtp_username", "smtp_password");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
