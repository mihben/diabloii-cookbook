using System;

namespace DiabloII_Cookbook.Api.DataTransferObjects
{
    public class ItemType
    {
        public Guid Id { get; }
        public string Group { get; }
        public string Name { get; }

        public ItemType(Guid id, string group, string name)
        {
            Id = id;
            Group = group;
            Name = name;
        }
    }
}