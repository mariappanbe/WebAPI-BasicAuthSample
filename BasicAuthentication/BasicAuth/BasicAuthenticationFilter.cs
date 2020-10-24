using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BasicAuthentication
{
    public class BasicAuthenticationFilter : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private const string BasicName = "Basic";
        private const string AuthorizationName = "Authorization";
        private readonly IUserService _userService;

        public BasicAuthenticationFilter(IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            ISystemClock clock,
            IUserService userService) : base(options, logger, encoder,clock)
        {
            this._userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!this.Request.Headers.ContainsKey(AuthorizationName))
            {
                return AuthenticateResult.NoResult();
            }

            if (!AuthenticationHeaderValue.TryParse(this.Request.Headers[AuthorizationName], out AuthenticationHeaderValue authenticationHeaderValue))
            {
                return AuthenticateResult.NoResult();
            }

            if (!BasicName.Equals(authenticationHeaderValue.Scheme, StringComparison.OrdinalIgnoreCase))
            {
                return AuthenticateResult.NoResult();
            }

            string[] users = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationHeaderValue.Parameter)).Split(":");
            
            if (users != null && users.Count() < 2)
            {
                return AuthenticateResult.NoResult();
            }

            if(!this._userService.IsAuthenticate(users[0], users[1]))
            {
                return AuthenticateResult.Fail("UnAuthorized user!!. please enter correct username and password");
            }

            var claim = new[] { new Claim(ClaimTypes.Name, users[0]) };
            var authenticationTicket = new AuthenticationTicket(new ClaimsPrincipal(new ClaimsIdentity(claim, Scheme.Name)), Scheme.Name);

            return AuthenticateResult.Success(authenticationTicket);
        }
    }
}
