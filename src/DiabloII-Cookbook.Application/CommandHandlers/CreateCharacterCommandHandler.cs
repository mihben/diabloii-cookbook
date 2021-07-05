using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Application.Contexts;
using DiabloII_Cookbook.Application.DatabaseContexts;
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
            await _context.Database.EnsureCreatedAsync(cancellationToken).ConfigureAwait(false);

            var id = Guid.NewGuid();
            _logger.LogDebug("Insert {id} character", id);

            if (await _context.Characters.AnyAsync(c => c.Account.BattleTag.Equals(command.BattleTag) && c.Name.ToLower().Equals(command.Name.ToLower())).ConfigureAwait(false))
            {
                _logger.LogInformation("{name} has been already created", command.Name);
                throw new VerificationException(402, $"{command.Name} has been already created");
            }

            using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);
            var account = await _context.Accounts.SingleOrDefaultAsync(ae => ae.BattleTag.Equals(command.BattleTag)).ConfigureAwait(false);
            if (account == null)
            {
                account = new AccountEntity
                {
                    Id = Guid.NewGuid(),
                    BattleTag = command.BattleTag
                };
                await _context.Accounts.AddAsync(account, cancellationToken).ConfigureAwait(false);
            }

            var character = new CharacterEntity { Id = id, Account = account, Class = command.Class, Name = command.Name, Level = command.Level, IsLadder = command.IsLadder, IsExpansion = command.IsExpansion };
            await _context.Characters.AddAsync(character, cancellationToken).ConfigureAwait(false);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
