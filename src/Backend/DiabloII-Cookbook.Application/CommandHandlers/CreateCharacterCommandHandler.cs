using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Application.Entities;
using Microsoft.Extensions.Logging;
using Netension.Request.Abstraction.Handlers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Application.CommandHandlers
{
    public class CreateCharacterCommandHandler : ICommandHandler<CreateCharacterCommand>
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<CreateCharacterCommandHandler> _logger;

        public CreateCharacterCommandHandler(DatabaseContext context, ILogger<CreateCharacterCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task HandleAsync(CreateCharacterCommand command, CancellationToken cancellationToken)
        {
            _context.Database.EnsureCreated();

            var id = Guid.NewGuid();
            _logger.LogDebug("Insert {id} character", id);

            await _context.AddAsync(new CharacterEntity { Id = id, Class = command.Class, Name = command.Name, Level = command.Level, IsLadder = command.IsLadder, IsExpansion = command.IsExpansion }, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
