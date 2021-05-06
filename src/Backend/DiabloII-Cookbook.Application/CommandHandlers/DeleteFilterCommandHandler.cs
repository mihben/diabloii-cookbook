using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Application.DatabaseContexts;
using Microsoft.Extensions.Logging;
using Netension.Request.Abstraction.Senders;
using Netension.Request.Infrastructure.EFCore.Handlers;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Application.CommandHandlers
{
    public class DeleteFilterCommandHandler : TransactionalCommandHandler<DeleteFilterCommand, DatabaseContext>
    {
        public DeleteFilterCommandHandler(DatabaseContext context, IQuerySender querySender, ILogger<DeleteFilterCommandHandler> logger)
            : base(context, querySender, logger)
        {
        }

        protected override async Task HandleInternalAsync(DeleteFilterCommand command, CancellationToken cancellationToken)
        {
            Context.Filters.Remove(await Context.Filters.FindAsync(new { command.Id }));
        }
    }
}
