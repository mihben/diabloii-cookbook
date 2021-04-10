using AutoFixture;
using DiabloII_Cookbook.Api.Commands;
using DiabloII_Cookbook.Api.Enumerations;
using Netension.Core;
using System;
using System.Linq;

namespace DiabloII_Cookbook.IntegrationTest.Builders
{
    public static class DataFactories
    {
        public static CreateCharacterCommand Create(string name)
        {
            var fixture = new Fixture();
            var random = new Random();

            var classes = Enumeration.GetAll<ClassEnumeration>().ToArray();

            return new CreateCharacterCommand(classes[random.Next(0, 6)].Name, name, random.Next(1, 99), fixture.Create<bool>(), fixture.Create<bool>());
        }

        public static CreateCharacterCommand Create()
        {
            return Create(new Fixture().Create<string>());
        }
    }
}
