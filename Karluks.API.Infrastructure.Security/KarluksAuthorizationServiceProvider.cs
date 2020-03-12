using System;
using Karluks.API.Infrastructure.Interface;

namespace Karluks.API.Infrastructure.Security
{

    public class KarluksAuthorizationServiceProvider : OAuthAuthorizationServerProvider,
    IKarluksAuthorizationServiceProvider
    {
        private readonly IUserRepository _authentication;
        private readonly string _publicClientId;
        private readonly string _systemInfo;

        public KarluksAuthorizationServiceProvider(IUserRepository userRepository, string publicClientId)
        {
            _authentication = userRepository;
            _publicClientId = publicClientId;
            _systemInfo = SystemBuildInformation.GetInformation();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
          //  var accessRoles = new HashSet<string> { "Admin", "Staff_Invoice_Admin", "Staff_Partners_Admin", "Staff_Noc" };
            var user = await _authentication.FindUser(context.UserName, context.Password);

            if (user.Object == null)
            {
                context.SetError("invalid_grant", user.OMessage.Value.ToString());
                return;
            }

            if (accessRoles.Contains(user.Object.ProfileName))
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Object.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, user.Object.ProfileName));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Object.Email));
                identity.AddClaim(new Claim(ClaimTypes.Surname, user.Object.LastName));
                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "as:client_id", context.ClientId ?? string.Empty
                    },
                    {
                        "userName", user.Object.UserName
                    },
                    {
                        "firstName", user.Object.FirstName
                    },
                    {
                        "lastName", user.Object.LastName
                    },
                    {
                        "id", user.Object.Id.ToString()
                    },
                    {
                        "profile", user.Object.ProfileName
                    },
                    {
                        "email", user.Object.Email
                    },
                    {
                        "key", user.Object.SaltKey
                    },
                    {
                        "system", _systemInfo
                    }
                });

                var ticket = new AuthenticationTicket(identity, props);
                context.Validated(ticket);
            }
            else
            {
                context.SetError("invalid_grant", "You don't have access permission; Please contact the administrator.");
            }
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null) context.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
                context.AdditionalResponseParameters.Add(property.Key, property.Value);

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId != _publicClientId) return Task.FromResult<object>(null);
            var expectedRootUri = new Uri(context.Request.Uri, "/");

            if (expectedRootUri.AbsoluteUri == context.RedirectUri) context.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.ClientId;

            if (originalClient != currentClient)
            {
                context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
                return Task.FromResult<object>(null);
            }

            // Change auth ticket for refresh token requests
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);

            var newClaim = newIdentity.Claims.FirstOrDefault(c => c.Type == "newClaim");
            if (newClaim != null) newIdentity.RemoveClaim(newClaim);
            newIdentity.AddClaim(new Claim("newClaim", "newValue"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }
    }
       
}
