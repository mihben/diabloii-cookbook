using Netension.Request;
using System;
using System.Collections.Generic;

namespace DiabloII_Cookbook.Api.Queries
{
    public class GetCharactersQuery : Query<IEnumerable<Guid>>
    {
        public string BattleTag { get; }

        public GetCharactersQuery(string battleTag)
        {
            BattleTag = battleTag;
        }
    }
}
