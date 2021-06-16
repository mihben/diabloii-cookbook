using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Api.Queries;
using DiabloII_Cookbook.Application.DatabaseContexts;
using DiabloII_Cookbook.Application.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Netension.Request.Abstraction.Handlers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Application.QueryHandlers
{
    public class GetItemTypesQueryHandler : IQueryHandler<GetItemTypesQuery, IEnumerable<ItemType>>
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<GetItemTypesQueryHandler> _logger;

        public GetItemTypesQueryHandler(DatabaseContext context, ILogger<GetItemTypesQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<ItemType>> HandleAsync(GetItemTypesQuery query, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Get item types");

            await _context.Database.EnsureCreatedAsync(cancellationToken);

            return (await _context.ItemTypes.ToListAsync(cancellationToken))
                        .Select(ite => ite.ToDto());
        }
    }
}
