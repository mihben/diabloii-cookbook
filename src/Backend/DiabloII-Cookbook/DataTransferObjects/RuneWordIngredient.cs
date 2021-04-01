using System;

namespace DiabloII_Cookbook.Api.DataTransferObjects
{
    public class RuneWordIngredient
    {
        public Guid Id { get; }
        public int Order { get; }
        public Rune Rune { get; }

        public RuneWordIngredient(Guid id, int order, Rune rune)
        {
            Id = id;
            Order = order;
            Rune = rune;
        }
    }
}
