using DiabloII_Cookbook.Api.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Client.Services
{
    public interface ICharacterService
    {
        Task<IEnumerable<Guid>> GetCharactersAsync(CancellationToken cancellationToken);
        Task<Character> GetCharacterAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(string @class, string name, int level, bool isExpansion, bool isLadder, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
