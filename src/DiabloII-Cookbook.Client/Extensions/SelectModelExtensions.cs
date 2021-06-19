using DiabloII_Cookbook.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Client.Extensions
{
    public static class SelectModelExtensions
    {
        public static IEnumerable<TItem> GetSelectedItems<TItem>(this IEnumerable<SelectModel<TItem>> models)
        {
            return models.Where(m => m.Selected).Select(m => m.Item).ToList();
        }
    }
}
