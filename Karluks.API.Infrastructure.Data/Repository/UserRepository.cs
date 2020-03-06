using System;
using System.Threading.Tasks;
using Karluks.API.Infrastructure.Common;
using Karluks.API.Infrastructure.DataProvider;
using Karluks.API.Infrastructure.Interface;
using Karluks.API.Infrastructure.Model;
using log4net;

namespace Karluks.API.Infrastructure.Data.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConnection connection, ILog log) : base(connection, log)
        {
        }

        public Task<Result<User>> FindUser(string userEmail)
        {
            throw new NotImplementedException();
        }
    }
}
