using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Application.Contexts;
using DiabloII_Cookbook.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Netension.Core.Exceptions;
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
            await _context.Database.EnsureCreatedAsync(cancellationToken);

            var id = Guid.NewGuid();
            _logger.LogDebug("Insert {id} character", id);

            if (await _context.Characters.AnyAsync(c => c.Name.ToLower().Equals(command.Name.ToLower())))
            {
                _logger.LogInformation("Character with name {name} has been already created", command.Name);
                throw new VerificationException(402, $"Character with name {command.Name} has been already created");
            }

            await _context.AddAsync(new CharacterEntity { Id = id, Class = command.Class, Name = command.Name, Level = command.Level, IsLadder = command.IsLadder, IsExpansion = command.IsExpansion }, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
