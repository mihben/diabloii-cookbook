using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiabloII_Cookbook.Client.Extensions
{
    public static class ItemTypeExtensions
    {
        public static IEnumerable<Filter> AsFilter(this IEnumerable<ItemType> itemTypes, string group)
        {
            return itemTypes.Where(it => it.Group.Equals(group, StringComparison.InvariantCultureIgnoreCase)).Select(it => new Filter(it)).ToList();
        }
    }
}
