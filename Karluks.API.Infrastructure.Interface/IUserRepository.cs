using System;
using System.Threading.Tasks;
using Karluks.API.Infrastructure.Common;
using Karluks.API.Infrastructure.Model;

namespace Karluks.API.Infrastructure.Interface
{
    public interface IUserRepository
    {
        Task<Result<User>> FindUser(string userEmail);
    }
}
