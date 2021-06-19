using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Client.Models;
using System;

namespace DiabloII_Cookbook.Client.Extensions
{
    public static class CharacterExtensions
    {
        public static string GetImage(this CharacterModel character)
        {
            return $"/assets/classic/classes/{character.Class.ToLower()}.gif";
        }
    }
}
