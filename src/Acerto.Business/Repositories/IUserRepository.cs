using Acerto.Business.Core.Auth;

namespace Acerto.Business.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByUsername(string username);
    }
}