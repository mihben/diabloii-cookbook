using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Application.DatabaseContexts;
using DiabloII_Cookbook.Application.Entities;
using DiabloII_Cookbook.Application.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Netension.Core.Exceptions;
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
            await _context.Database.EnsureCreatedAsync(cancellationToken);

            _logger.LogDebug("Update {id} character", command.Id);

            var character = await _context.Characters.Include(ce => ce.Runes).SingleOrDefaultAsync(ce => ce.Id == command.Id, cancellationToken);

            if (character is null)
            {
                _logger.LogError("{id} character does not exist", command.Id);
                throw new VerificationException(204, $"Character does not exist");
            }

            character.Level = command.Level;
            character.Runes.Clear();
            foreach (var rune in command.Runes)
            {
                character.Runes.Add(new CharacterRuneEntity
                {
                    Character = character,
                    CharacterId = character.Id,
                    Rune = rune.ToEntity(),
                    RuneId = rune.Id
                });
            }
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
