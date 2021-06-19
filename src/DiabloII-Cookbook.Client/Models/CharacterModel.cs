using DiabloII_Cookbook.Api.DataTransferObjects;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DiabloII_Cookbook.Client.Models
{
    public class CharacterModel
    {
        public Guid Id { get; }
        public string Class { get; }
        public string Name { get; }
        public int Level { get; set; }
        public bool IsExpansion { get; }
        public bool IsLadder { get; }

        public CharacterModel(Guid id, string @class, string name, int level, bool isExpansion, bool isLadder)
        {
            Id = id;
            Class = @class;
            Name = name;
            Level = level;
            IsExpansion = isExpansion;
            IsLadder = isLadder;
        }
    }
}
