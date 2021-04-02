using DiabloII_Cookbook.Api.DataTransferObjects;
using Netension.Request;
using System.Collections.Generic;

namespace DiabloII_Cookbook.Api.Queries
{
    public class GetRuneWordsQuery : Query<IEnumerable<RuneWord>>
    {
        public IEnumerable<Rune> Runes { get; }
        public IEnumerable<ItemType> ItemTypes { get; }

        public GetRuneWordsQuery(IEnumerable<ItemType> itemTypes, IEnumerable<Rune> runes)
        {
            ItemTypes = itemTypes;
            Runes = runes;
        }
    }
}
