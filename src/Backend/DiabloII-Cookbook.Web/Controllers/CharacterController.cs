using DiabloII_Cookbook.Api.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Netension.Request.Abstraction.Senders;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICommandSender _commandSender;
        private readonly ILogger<CharacterController> _logger;

        public CharacterController(ICommandSender commandSender, ILogger<CharacterController> logger)
        {
            _commandSender = commandSender;
            _logger = logger;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> InsertAsync(CreateCharacterCommand command, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Create {name} character", command.Name);
            await _commandSender.SendAsync(command, cancellationToken);
            return Accepted();
        }
    }
}
