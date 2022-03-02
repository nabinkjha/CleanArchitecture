using ECom.Application.DTOs.Mail;
using System.Threading.Tasks;

namespace ECom.Application.Interfaces.Shared
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}