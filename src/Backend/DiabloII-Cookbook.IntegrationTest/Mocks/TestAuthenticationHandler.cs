using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.IntegrationTest.Mocks
{
    public class MockAuthenticationSchemeOptions : AuthenticationSchemeOptions
    {
        public string BattleTag { get; set; }
    }

    public class TestAuthenticationHandler : AuthenticationHandler<MockAuthenticationSchemeOptions>
    {
        public TestAuthenticationHandler(IOptionsMonitor<MockAuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) 
            : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Context.Request.Headers.ContainsKey("Authorization")) return Task.FromResult(AuthenticateResult.Fail("Unathorized"));

            var claims = new[] { new Claim("battle_tag", Options.BattleTag) };
            var identity = new ClaimsIdentity(claims, "IntegrationTestScheme");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, "IntegrationTestScheme");

            var result = AuthenticateResult.Success(ticket);

            return Task.FromResult(result);
        }
    }
}
