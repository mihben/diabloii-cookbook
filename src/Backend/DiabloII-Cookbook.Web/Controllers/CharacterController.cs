﻿using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Netension.Request.Abstraction.Senders;
using System;
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
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody]UpdateCharacter parameter, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Update {id} character", id);
            await _commandSender.SendAsync(new UpdateCharacterCommand(id, parameter.Level, parameter.Runes), cancellationToken);
            return Accepted();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Delete {id} character", id);
            await _commandSender.SendAsync(new DeleteCharacterCommand(id), cancellationToken);
            return Accepted();
        }
    }
}
