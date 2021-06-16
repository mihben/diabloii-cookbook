using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Api.Queries;
using DiabloII_Cookbook.Application.Contexts;
using DiabloII_Cookbook.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize(Policy = "battle-tag")]
    public class CharacterController : ControllerBase
    {
        private readonly ICommandSender _commandSender;
        private readonly ILogger<CharacterController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IQuerySender _querySender;

        public CharacterController(IQuerySender querySender, ICommandSender commandSender, IHttpContextAccessor httpContextAccessor, ILogger<CharacterController> logger)
        {
            _commandSender = commandSender;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _querySender = querySender;
        }

        [HttpGet]
        public async Task<IEnumerable<Guid>> GetAsync(CancellationToken cancellationToken)
        {
            return await _querySender.QueryAsync(new GetCharactersQuery(_httpContextAccessor.HttpContext.User.FindFirst("battle_tag").Value), cancellationToken);
        }

        [HttpGet("{id:guid}")]
        public async Task<Character> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _querySender.QueryAsync(new GetCharacterDetailQuery(id), cancellationToken);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody]CreateCharacter command, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Create {name} character", command.Name);
            await _commandSender.SendAsync(new CreateCharacterCommand(_httpContextAccessor.HttpContext.User.FindFirst("battle_tag").Value, command.Class, command.Name, command.Level, command.IsLadder, command.IsExpansion), cancellationToken);
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
