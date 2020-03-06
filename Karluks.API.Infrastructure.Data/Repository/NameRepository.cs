// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NameRepository.cs" company="Karluks">
//   Copyright (c) Karluks. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Karluks.API.Infrastructure.Common;
using Karluks.API.Infrastructure.DataProvider;
using Karluks.API.Infrastructure.Interface;
using Karluks.API.Infrastructure.Model.names;
using log4net;

namespace Karluks.API.Infrastructure.Data.Repository
{
    public class NameRepository : BaseRepository, INameRepository
    {
        public NameRepository(IConnection connection,ILog log) : base(connection,log)
        {
        }

        public async Task<Result<IList<UyghurName>>> GetUyghurName()
        {
            var uyghurNames = new Result<IList<UyghurName>> { Object = new List<UyghurName>() };
            await GetResultAsync("GET_UYGHUR_NAMES",
                rdReader =>
                {
                    uyghurNames.Object.Read(rdReader);
                    return uyghurNames;
                });
            return uyghurNames;
            
        }

        public Task<Result<UyghurName>> GetUyghurName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result<UyghurName>> UpdateUyghurName(UyghurName uyghurName)
        {
            throw new System.NotImplementedException();
        }

      public Task<Result<UyghurName>> AddUyghurName(UyghurName uyghurName)
        {
            throw new System.NotImplementedException();
        }

    }
}
