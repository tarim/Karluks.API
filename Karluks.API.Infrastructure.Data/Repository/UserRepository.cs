using System;
using System.Threading.Tasks;
using Karluks.API.Infrastructure.Common;
using Karluks.API.Infrastructure.DataProvider;
using Karluks.API.Infrastructure.Interface;
using Karluks.API.Infrastructure.Model;
using Microsoft.Extensions.Logging;

namespace Karluks.API.Infrastructure.Data.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly ILogger<UserRepository> logger;
        public UserRepository(IConnection connection, ILogger<UserRepository> log) : base(connection)
        {
            logger = log;
        }

        public Task<Result<User>> FindUser(string userEmail)
        {
            throw new NotImplementedException();
        }
    }
}
