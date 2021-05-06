using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Application.DatabaseContexts;
using DiabloII_Cookbook.Application.Mappers;
using Microsoft.Extensions.Logging;
using Netension.Request.Abstraction.Senders;
using Netension.Request.Infrastructure.EFCore.Handlers;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Application.CommandHandlers
{
    public class AddItemTypeFilterCommandHandler : TransactionalCommandHandler<AddItemTypeFilterCommand, DatabaseContext>
    {
        public AddItemTypeFilterCommandHandler(DatabaseContext context, IQuerySender querySender, ILogger<AddItemTypeFilterCommandHandler> logger)
            : base(context, querySender, logger)
        {
        }

        protected override async Task HandleInternalAsync(AddItemTypeFilterCommand command, CancellationToken cancellationToken)
        {
            await Context.Database.EnsureCreatedAsync(cancellationToken);

            await Context.Filters.AddAsync(command.ToEntity(), cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
