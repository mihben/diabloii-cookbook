using DiabloII_Cookbook.Application.Contexts;
using LightInject;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Netension.Core.Exceptions;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Web.Middlewares
{
    public class AccountContextMiddleware
    {
        private const string CLAIM = "battle_tag";

        private readonly RequestDelegate _next;
        private readonly IAccountContextMutator _accountContextMutator;
        private readonly ILogger<AccountContextMiddleware> _logger;

        public AccountContextMiddleware(RequestDelegate next, IAccountContextMutator accountContextMutator, ILogger<AccountContextMiddleware> logger)
        {
            _next = next;
            _accountContextMutator = accountContextMutator;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            _logger.LogDebug("Looking for {} claim", CLAIM);
            var claim = httpContext.User.FindFirst(CLAIM);
            if (claim is null)
            {
                _logger.LogDebug("{claim} claim not found", CLAIM);
                throw new VerificationException(403, "Unknown account");
            }

            _accountContextMutator.SetBattleTag(claim.Value);

            await _next.Invoke(httpContext);
        }
    }
}
