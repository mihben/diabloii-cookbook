using DiabloII_Cookbook.Api.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Client.Services
{
    public interface IRuneService
    {
        Task<IEnumerable<Rune>> GetRunesAsync(CancellationToken cancellationToken);
        Task<IEnumerable<RuneWord>> GetRuneWordsAsync(CancellationToken cancellationToken);
        Task<IEnumerable<RuneWord>> GetRuneWordsAsync(IEnumerable<Rune> runes, IEnumerable<ItemType> itemTypes, CancellationToken cancellationToken);
    }
}
