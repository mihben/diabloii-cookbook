using Netension.Request;
using System;

namespace DiabloII_Cookbook.Api.Commands
{
    public class DeleteCharacterCommand : Command
    {
        public Guid Id { get; }

        public DeleteCharacterCommand(Guid id)
        {
            Id = id;
        }
    }
}
