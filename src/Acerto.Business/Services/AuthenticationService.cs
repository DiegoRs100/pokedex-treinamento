using Acerto.Business.Core.Auth;
using Acerto.Business.Core.Notifications;
using Acerto.Business.Repositories;
using Microsoft.Extensions.Options;

namespace Acerto.Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly INotifier _notifier;
        private readonly AuthSettings _authSettings;

        public AuthenticationService(IUserRepository userRepository, 
                                     INotifier notifier,
                                     IOptions<AuthSettings> options)
        {
            _userRepository = userRepository;
            _notifier = notifier;
            _authSettings = options.Value;
        }

        public async Task<string?> LoginAsync(LoginModel login)
        {
            var user = await _userRepository.GetByUsername(login.Username);

            if (user == null || user.Password != CryptographyHelper.EncryptToMD5(login.Password)) 
            {
                _notifier.Notify("Usuário ou senha incorretos.");
                return null;
            }

            return JwtHelper.GenerateTokenJwt(login.Username, _authSettings);
        }
    }
}