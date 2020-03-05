using System;
using log4net;

namespace Karluks.API.Infrastructure.Data
{
    public class Base
    {
        

        private readonly IConnection Connection;

        protected Base(IConnection connection)
        {
            this.Connection = connection;
        }

        protected async Task GetResultAsync<T>(string query, Func<IDataReader, Results<T>> customRead, params IDbDataParameter[] parameters) where T : class
        {
            await this.Connection.GetResultAsync<T>(query, customRead, parameters);
        }

        protected async Task<int> ExecuteNonQueryAsync(string query, params IDbDataParameter[] parameters)
        {
            return await this.Connection.ExecuteNonQueryAsync(query, parameters);
        }

        protected IDbDataParameter GetParameter(string paramName, object paramValue, OracleDbType type)
        {
            return this.Connection.GetParameter(paramName, paramValue, type);
        }

        protected IDbDataParameter GetParameter(string paramName, OracleDbType type, int size)
        {
            return this.Connection.GetParameter(paramName, type, size);
        }

        protected IDbDataParameter GetParameter(string paramName, OracleDbType type)
        {
            return this.Connection.GetParameter(paramName, type);
        }
    }
}
