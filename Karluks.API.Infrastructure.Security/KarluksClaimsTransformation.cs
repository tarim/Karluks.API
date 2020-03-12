using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Karluks.API.Infrastructure.Interface;
using Microsoft.AspNetCore.Http;


namespace Karluks.API.Infrastructure.Security
{
    public class KarluksClaims
    {
        private readonly Func<IDictionary<string, object>, Task> _next;
        private readonly IUserRepository _userRepository;
        private IHttpContextAccessor _contextAccessor;
        private HttpContext Context { get { return _contextAccessor.HttpContext; } }
        public KarluksClaims(Func<IDictionary<string, object>, Task> next, IUserRepository userRepository)
        {
            _next = next;
            _userRepository = userRepository;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {

            if (Context.User is ClaimsPrincipal claimsPrincipal && claimsPrincipal.Identity.IsAuthenticated)
            {
                var result = await _userRepository.FindUser(claimsPrincipal.Identity.Name);
                if (result.Object != null)
                {
                    foreach (var role in result.Object.Roles)
                    {
                        ((ClaimsIdentity)claimsPrincipal.Identity).AddClaim(new Claim(ClaimTypes.Role,
                            role, ClaimValueTypes.String, "AADGuide"));
                    }

                    Context.User = claimsPrincipal;
                }
                // else HttpContext.Current.Response.StatusCode = 401;
            }
            await _next(env);

        }
    }
}
