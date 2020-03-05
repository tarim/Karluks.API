// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExecuteStatus.cs" company="Karluks">
//   Copyright (c) Karluks. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Karluks.API.Infrastructure.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ExecuteStatus
    {
        Success,
        Failed,
        Hold,
        Error

    }
}
