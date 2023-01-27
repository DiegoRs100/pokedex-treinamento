using Acerto.Business.Core.Auth;
using Acerto.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acerto.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> GetByUsername(string username)
        {
            return Task.FromResult(new User()
            {
                Username = username,
                Password = "81dc9bdb52d04dc20036dbd8313ed055" // 1234
            });
        }
    }
}