using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiabloII_Cookbook.Client.Extensions
{
    public static class ItemTypeExtensions
    {
        public static IEnumerable<SelectModel<ItemType>> MakeSelectable(this IEnumerable<ItemType> itemTypes, string group)
        {
            return itemTypes.Where(it => it.Group.Equals(group, StringComparison.InvariantCultureIgnoreCase)).Select(it => new SelectModel<ItemType>(it)).ToList();
        }

        public static string FilteredBy(this ItemType itemType, IEnumerable<ItemType> selectedItemTypes)
        {
            return selectedItemTypes.Any(it => it.Id.Equals(itemType.Id)) ? "filtered-by" : "";
        }
    }
}
