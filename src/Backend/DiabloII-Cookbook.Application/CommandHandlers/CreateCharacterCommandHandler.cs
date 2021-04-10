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
        private readonly IAccountContext _accountContext;
        private readonly ILogger<CreateCharacterCommandHandler> _logger;

        public CreateCharacterCommandHandler(DatabaseContext context, IAccountContext accountContext, ILogger<CreateCharacterCommandHandler> logger)
        {
            _context = context;
            _accountContext = accountContext;
            _logger = logger;
        }

        public async Task HandleAsync(CreateCharacterCommand command, CancellationToken cancellationToken)
        {
            await _context.Database.EnsureCreatedAsync(cancellationToken);

            var id = Guid.NewGuid();
            _logger.LogDebug("Insert {id} character", id);

            if (await _context.Characters.AnyAsync(c => c.Account.BattleTag.Equals(_accountContext.BattleTag) && c.Name.ToLower().Equals(command.Name.ToLower())))
            {
                _logger.LogInformation("{name} has been already created", command.Name);
                throw new VerificationException(402, $"{command.Name} has been already created");
            }

            using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                var account = await _context.Accounts.SingleOrDefaultAsync(ae => ae.BattleTag.Equals(_accountContext.BattleTag));
                if (account == null)
                {
                    account = new AccountEntity
                    {
                        Id = Guid.NewGuid(),
                        BattleTag = _accountContext.BattleTag
                    };
                    await _context.Accounts.AddAsync(account, cancellationToken);
                }

                var character = new CharacterEntity { Id = id, Account = account, Class = command.Class, Name = command.Name, Level = command.Level, IsLadder = command.IsLadder, IsExpansion = command.IsExpansion };
                await _context.Characters.AddAsync(character, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
        }
    }
}
