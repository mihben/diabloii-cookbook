using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Application.DatabaseContexts;
using DiabloII_Cookbook.Application.Entities;
using Microsoft.Extensions.Logging;
using Netension.Request.Abstraction.Handlers;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Application.CommandHandlers
{
    public class DeleteCharacterCommandHandler : ICommandHandler<DeleteCharacterCommand>
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<DeleteCharacterCommandHandler> _logger;

        public DeleteCharacterCommandHandler(DatabaseContext context, ILogger<DeleteCharacterCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task HandleAsync(DeleteCharacterCommand command, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Delete {id} character", command.Id);

            var character = await _context.FindAsync<CharacterEntity>(new object[] { command.Id }, cancellationToken);
            _context.Remove(character);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
