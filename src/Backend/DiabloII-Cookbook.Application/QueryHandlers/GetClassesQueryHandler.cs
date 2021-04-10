using DiabloII_Cookbook.Api.Enumerations;
using DiabloII_Cookbook.Api.Queries;
using Microsoft.Extensions.Logging;
using Netension.Core;
using Netension.Request.Abstraction.Handlers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Application.QueryHandlers
{
    public class GetClassesQueryHandler : IQueryHandler<GetClassesQuery, IEnumerable<string>>
    {
        private readonly ILogger<GetClassesQuery> _logger;

        public GetClassesQueryHandler(ILogger<GetClassesQuery> logger)
        {
            _logger = logger;
        }

        public Task<IEnumerable<string>> HandleAsync(GetClassesQuery query, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Get classes");
            return Task.FromResult(Enumeration.GetAll<ClassEnumeration>().Select(ce => ce.Name));
        }
    }
}
