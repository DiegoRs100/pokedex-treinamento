using Acerto.Business.Core.Auth;

namespace Acerto.Business.Services
{
    public interface IAuthenticationService
    {
        Task<string?> LoginAsync(LoginModel login);
    }
}