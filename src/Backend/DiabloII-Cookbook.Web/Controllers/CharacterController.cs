using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Api.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Netension.Request.Abstraction.Senders;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<IActionResult> InsertAsync(CreateCharacterCommand command, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Create {name} character", command.Name);
            await _commandSender.SendAsync(command, cancellationToken);
            return Accepted();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, int level, bool isExpansion, bool isLadder, IEnumerable<Rune> runes, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Create {id} character", id);
            await _commandSender.SendAsync(new UpdateCharacterCommand(id, level, isExpansion, isLadder, runes), cancellationToken);
            return Accepted();
        }
    }
}
