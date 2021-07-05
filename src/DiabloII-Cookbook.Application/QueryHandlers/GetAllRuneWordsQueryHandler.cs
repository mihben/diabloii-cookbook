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
    public class GetAllRuneWordsQueryHandler : IQueryHandler<GetAllRuneWordsQuery, IEnumerable<RuneWord>>
    {
        private readonly DatabaseContext _context;
        private readonly ILogger _logger;

        public GetAllRuneWordsQueryHandler(DatabaseContext context, ILogger<GetAllRuneWordsQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<RuneWord>> HandleAsync(GetAllRuneWordsQuery query, CancellationToken cancellationToken)
        {
            await _context.Database.EnsureCreatedAsync(cancellationToken).ConfigureAwait(false);

            var runeWords = await _context.RuneWords
                            .AsNoTracking()
                            .Include(rw => rw.Ingredients)
                                .ThenInclude(rwi => rwi.Rune)
                            .Include(rw => rw.ItemTypes)
                                .ThenInclude(rwite => rwite.ItemType)
                            .Include(rw => rw.Properties)
                                .ThenInclude(rwp => rwp.Skill)
                             .OrderBy(rw => rw.Level)
                            .ToListAsync(cancellationToken)
                            .ConfigureAwait(false);

            return runeWords.Select(rw => rw.ToDto());
        }
    }
}
