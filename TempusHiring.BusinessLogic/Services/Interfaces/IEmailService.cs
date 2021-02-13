using System.Threading.Tasks;

namespace TempusHiring.BusinessLogic.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
