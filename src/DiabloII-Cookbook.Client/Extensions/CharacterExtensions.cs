using DiabloII_Cookbook.Api.DataTransferObjects;
using System;

namespace DiabloII_Cookbook.Client.Extensions
{
    public static class CharacterExtensions
    {
        public static string GetImage(this Character character)
        {
            return $"/assets/classic/classes/{character.Class.ToLower()}.gif";
        }
    }
}
