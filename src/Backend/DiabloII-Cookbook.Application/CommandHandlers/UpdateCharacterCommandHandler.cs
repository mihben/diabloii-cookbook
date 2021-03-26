using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Application.Contexts;
using DiabloII_Cookbook.Application.Entities;
using DiabloII_Cookbook.Application.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Netension.Request.Abstraction.Handlers;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Application.CommandHandlers
{
    public class UpdateCharacterCommandHandler : ICommandHandler<UpdateCharacterCommand>
    {
        private readonly CharacterContext _context;
        private readonly ILogger<UpdateCharacterCommandHandler> _logger;

        public UpdateCharacterCommandHandler(CharacterContext context, ILogger<UpdateCharacterCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task HandleAsync(UpdateCharacterCommand command, CancellationToken cancellationToken)
        {
            await _context.Database.EnsureCreatedAsync(cancellationToken);

            _logger.LogDebug("Update {id} character", command.Id);

            var character = await _context.Characters.Include(ce => ce.Runes).SingleOrDefaultAsync(ce => ce.Id == command.Id, cancellationToken);
            character.Level = command.Level;
            character.Runes.Clear();
            foreach (var rune in command.Runes)
            {
                character.Runes.Add(new CharacterRuneEntity {
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
