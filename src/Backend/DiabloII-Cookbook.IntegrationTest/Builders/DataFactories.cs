using AutoFixture;
using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Api.Enumerations;
using DiabloII_Cookbook.Application.Entities;
using Netension.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiabloII_Cookbook.IntegrationTest.Builders
{
    public static class DataFactories
    {
        public static CreateCharacterCommand CreateCharacterCommand(this Fixture fixture, string name)
        {
            var random = new Random();
            var classes = Enumeration.GetAll<ClassEnumeration>().ToArray();
            return fixture.Build<CreateCharacterCommand>().FromFactory(() => new CreateCharacterCommand(fixture.Create<string>(), classes[random.Next(0, 6)].Name, name, random.Next(1, 99), fixture.Create<bool>(), fixture.Create<bool>())).Create();
        }

        public static CreateCharacterCommand CreateCharacterCommand(this Fixture fixture)
        {
            return fixture.CreateCharacterCommand(fixture.Create<string>());
        }

        public static CharacterEntity CreateCharacterEntity(this Fixture fixture, string battleTag, IEnumerable<CharacterRuneEntity> runes = null, Guid? id = null)
        {
            return fixture.Build<CharacterEntity>()
                        .With(ce => ce.Id, id ?? Guid.NewGuid())
                        .With(ce => ce.Account, new AccountEntity { Id = Guid.NewGuid(), BattleTag = battleTag })
                        .Without(ce => ce.Filters)
                        .With(ce => ce.Runes, runes ?? new List<CharacterRuneEntity>())
                        .With(ce => ce.Level, new Random().Next(1, 99))
                    .Create();
        }

        public static CharacterEntity CreateCharacterEntity(this Fixture fixture, IEnumerable<CharacterRuneEntity> runes = null, Guid? id = null)
        {
            return fixture.CreateCharacterEntity("integration_test", runes, id);
        }

        public static ItemTypeEntity CreateItemTypeEntity(this Fixture fixture, Guid itemTypeId)
        {
            return fixture.Build<ItemTypeEntity>()
                        .With(ite => ite.Id, itemTypeId)
                        .Without(ite => ite.Filters)
                        .Without(ite => ite.RuneWords)
                    .Create();
        }
    }
}
