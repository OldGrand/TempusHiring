using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using TempusHiring.BusinessLogic.DataTransferObjects;
using TempusHiring.BusinessLogic.DataTransferObjects.Account;

namespace TempusHiring.BusinessLogic.Services.Interfaces
{
    public interface IAccountService
    {
        Task LoginAsync(LoginDTO loginModel, bool lockoutOnFailure);
        Task RegisterAsync(RegisterDTO userModel, string claimRole);
        Task CompleteEmailConfirmationAsync(string email, string confirmToken);
        Task LogoutAsync();
        AuthenticationProperties ConfigureExternalAuthentication(string provider, string redirectUrl);
        Task ExternalLoginAsync();
        Task ExternalRegisterAsync(UserDTO userDTO);
        Task<string> GenerateEmailConfirmationAsync(string email);
        Task<string> GeneratePasswordResetTokenAsync(string email);
        Task ResetPasswordAsync(ResetPasswordDTO resetPasswordModel);
    }
}
