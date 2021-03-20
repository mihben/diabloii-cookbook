using DiabloII_Cookbook.Api.DataTransferObjects;
using Netension.Request;
using System;

namespace DiabloII_Cookbook.Api.Queries
{
    public class GetCharacterDetailQuery : Query<Character>
    {
        public Guid Id { get; }

        public GetCharacterDetailQuery(Guid id)
        {
            Id = id;
        }
    }
}
