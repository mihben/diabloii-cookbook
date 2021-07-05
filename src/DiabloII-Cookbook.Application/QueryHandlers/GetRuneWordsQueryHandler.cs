using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Api.Queries;
using DiabloII_Cookbook.Application.DatabaseContexts;
using DiabloII_Cookbook.Application.Mappers;
using Microsoft.EntityFrameworkCore;
using Netension.Request.Abstraction.Handlers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Application.QueryHandlers
{
    public class GetRuneWordsQueryHandler : IQueryHandler<GetRuneWordsQuery, IEnumerable<RuneWord>>
    {
        private readonly DatabaseContext _context;

        public GetRuneWordsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RuneWord>> HandleAsync(GetRuneWordsQuery query, CancellationToken cancellationToken)
        {
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

            return runeWords
                    .Where(rw => rw.ItemTypes.Any(rwite => query.ItemTypes.Any(itf => itf.Id.Equals(rwite.ItemType.Id))))
                    .Where(rw => rw.Ingredients.All(rwi => query.Runes.Any(itf => itf.Id.Equals(rwi.Rune.Id))))
                    .Select(rw => rw.ToDto());
        }
    }
}
