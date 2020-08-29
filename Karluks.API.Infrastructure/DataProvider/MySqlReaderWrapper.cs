
using System.Data;
using Microsoft.Extensions.Logging;


namespace Karluks.API.Infrastructure.DataProvider
{
    internal class MySqlReaderWrapper : DataReaderWrapper
    {
        public long FetchSize
        {
            get;set;
        }

        public MySqlReaderWrapper( IDataReader reader)
            : base(reader)
        {
           // if (rowNum > 0)
          //  {
          //      var r = (MySqlDataReader)_reader;
          //      r.FetchSize = r.RowSize * rowNum;
          //  }
        }
    }
}
