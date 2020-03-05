using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Karluks.API.Infrastructure.Model.names;

namespace Karluks.API.Repository
{
    public class NamesRepository
    {
        public async Task<IList<UyghurName>> UyghurNames()
        {
            return await new List<UyghurName>();
        }
    }
}
