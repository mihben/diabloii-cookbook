using Netension.Request;
using System;

namespace DiabloII_Cookbook.Api.Commands
{
    public class DeleteFilterCommand : Command
    {
        public Guid Id { get; }

        public DeleteFilterCommand(Guid id)
        {
            Id = id;
        }
    }
}
