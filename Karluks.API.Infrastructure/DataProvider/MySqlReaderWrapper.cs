using System;
using System.Data;
using log4net;
using MySql.Data.MySqlClient;

namespace Karluks.API.Infrastructure.DataProvider
{
    internal class MySqlReaderWrapper : DataReaderWrapper
    {
        public long FetchSize
        {
            get;set;
        }

        public MySqlReaderWrapper(ILog logger, IDataReader reader)
            : base(logger, reader)
        {
           // if (rowNum > 0)
          //  {
          //      var r = (MySqlDataReader)_reader;
          //      r.FetchSize = r.RowSize * rowNum;
          //  }
        }
    }
}
