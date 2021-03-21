using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Application.Entities;
using Microsoft.Extensions.Logging;
using Netension.Request.Abstraction.Handlers;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Application.CommandHandlers
{
    public class UpdateCharacterCommandHandler : ICommandHandler<UpdateCharacterCommand>
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<UpdateCharacterCommandHandler> _logger;

        public UpdateCharacterCommandHandler(DatabaseContext context, ILogger<UpdateCharacterCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task HandleAsync(UpdateCharacterCommand command, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Update {id} character", command.Id);

            var character = await _context.FindAsync<CharacterEntity>(new object[] { command.Id }, cancellationToken);
            character.Level = command.Level;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
