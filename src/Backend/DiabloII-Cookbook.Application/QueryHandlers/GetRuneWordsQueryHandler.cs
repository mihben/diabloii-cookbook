﻿using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Api.Queries;
using DiabloII_Cookbook.Application.Contexts;
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
    public class GetRuneWordsQueryHandler : IQueryHandler<GetRuneWordsQuery, IEnumerable<RuneWord>>
    {
        private readonly DatabaseContext _context;
        private readonly ILogger _logger;

        public GetRuneWordsQueryHandler(DatabaseContext context, ILogger<GetRuneWordsQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<RuneWord>> HandleAsync(GetRuneWordsQuery query, CancellationToken cancellationToken)
        {
            await _context.Database.EnsureCreatedAsync(cancellationToken);

            return (await _context.RuneWords
                            .AsNoTracking()
                            .Include(rw => rw.Ingredients)
                                .ThenInclude(rwi => rwi.Rune)
                            .Include(rw => rw.ItemTypes)
                                .ThenInclude(rwite => rwite.ItemType)
                            .Include(rw => rw.Properties)
                                .ThenInclude(rwp => rwp.Skill)
                            .ToListAsync(cancellationToken))
                        .Select(rw => rw.ToDto());
        }
    }
}
