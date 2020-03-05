
using log4net;

namespace Karluks.API.Infrastructure.DataProvider
{
    public abstract class Base
    {
        protected readonly ILog Log;
        protected Base(ILog log)
        {
            
            Log = log;
        }

    }
}
