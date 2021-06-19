using DiabloII_Cookbook.Api.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Client.Services
{
    public interface IFilterService
    {
        Task<IEnumerable<ItemType>> GetItemTypesAsync(CancellationToken cancellationToken);
    }
}
