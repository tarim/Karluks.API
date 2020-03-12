using System;
using Karluks.API.Infrastructure.Common.Enums;

namespace Karluks.API.Infrastructure.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public StatusType Status { get; set; }
        public ProfileType Profile { get; set; }
        public string[] Roles { get; set; }
        public string Description { get; set; }
    }
}
