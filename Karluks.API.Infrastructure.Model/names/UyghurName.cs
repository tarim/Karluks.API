// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UyghurName.cs" company="Karluks">
//   Copyright (c) Karluks. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Karluks.API.Infrastructure.Common.Enums;

namespace Karluks.API.Infrastructure.Model.names
{
    public class UyghurName
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Origin { get; set; }

        public SexType Sex { get; set; }

        public bool IsFamilyName { get; set; }

        public string Description { get; set; }
    }
}
