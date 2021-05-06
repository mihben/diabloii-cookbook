using DiabloII_Cookbook.Api.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Netension.Request.Abstraction.Senders;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "battle-tag")]
    public class FilterController : ControllerBase
    {
        private readonly ICommandSender _commandSender;

        public FilterController(ICommandSender commandSender)
        {
            _commandSender = commandSender;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddItemTypeFilterCommand command, CancellationToken cancellationToken)
        {
            await _commandSender.SendAsync(command, cancellationToken);
            return Accepted();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _commandSender.SendAsync(new DeleteFilterCommand(id), cancellationToken);
            return Accepted();
        }
    }
}
