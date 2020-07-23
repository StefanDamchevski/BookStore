using BookStore.Data;
using BookStore.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BookStore.Customization.Auth
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {
        private readonly IApplicationRepository applicationRepository;

        public ApiKeyAuthenticationHandler(
         IOptionsMonitor<ApiKeyAuthenticationOptions> options,
         ILoggerFactory logger,
         UrlEncoder encoder,
         ISystemClock clock,
         IApplicationRepository applicationRepository
         ) : base(options, logger, encoder, clock)
        {
            this.applicationRepository = applicationRepository;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.NoResult();
            }
            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue headerValue))
            {
                return AuthenticateResult.NoResult();
            }

            if (headerValue.Scheme != Options.Scheme)
            {
                return AuthenticateResult.NoResult();
            }

            string apiKey = headerValue.Parameter;

            Application application = await applicationRepository.GetApplicationAsync(apiKey);
            if (application != null)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, application.Name)
                };

                ClaimsIdentity identity = new ClaimsIdentity(claims, Options.AuthenticationType);
                List<ClaimsIdentity> identities = new List<ClaimsIdentity> { identity };
                ClaimsPrincipal principal = new ClaimsPrincipal(identities);
                AuthenticationTicket ticket = new AuthenticationTicket(principal, Options.Scheme);

                return AuthenticateResult.Success(ticket);
            }
            return AuthenticateResult.Fail("Invalid ApiKey");
        }
    }
}
