using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Api.Queries;
using DiabloII_Cookbook.Application.Contexts;
using DiabloII_Cookbook.Application.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Netension.Request.Abstraction.Handlers;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Application.QueryHandlers
{
    public class GetCharacterDetailQueryHandler : IQueryHandler<GetCharacterDetailQuery, Character>
    {
        private readonly CharacterContext _context;
        private readonly ILogger<GetCharacterDetailQueryHandler> _logger;

        public GetCharacterDetailQueryHandler(CharacterContext context, ILogger<GetCharacterDetailQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Character> HandleAsync(GetCharacterDetailQuery query, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Get {id} character detail", query.Id);
            return (await _context.Characters.Include(c => c.Runes).ThenInclude(ce => ce.Rune).SingleOrDefaultAsync(c => c.Id == query.Id, cancellationToken))
                    .ToDto();
        }
    }
}
