using System;
using System.Data;
using System.Threading.Tasks;
using Karluks.API.Infrastructure.Common;
using MySql.Data.MySqlClient;

namespace Karluks.API.Infrastructure.Interface
{
    public interface IConnection
    {
        IDbDataParameter GetParameter(string paramName, object paramValue, MySqlDbType type);
        IDbDataParameter GetParameter(string paramName, MySqlDbType type, int size);
        Task GetResultAsync<T>(string query, Func<IDataReader, Results<T>> customRead, params IDbDataParameter[] parameters) where T : class;
        Task<int> ExecuteNonQueryAsync(string query, params IDbDataParameter[] parameters);

    }
}
