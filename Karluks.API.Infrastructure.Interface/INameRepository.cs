// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INameRepository.cs" company="Karluks">
//   Copyright (c) Karluks. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Karluks.API.Infrastructure.Common;
using Karluks.API.Infrastructure.Model.names;

namespace Karluks.API.Infrastructure.Interface
{
    public interface INameRepository
    {
        Task<Result<IList<UyghurName>>> GetUyghurName();

        Task<Result<UyghurName>> GetUyghurName(string name);

        Task<Result<UyghurName>> AddUyghurName(UyghurName uyghurName);

        Task<Result<UyghurName>> UpdateUyghurName(UyghurName uyghurName);
    }
}
