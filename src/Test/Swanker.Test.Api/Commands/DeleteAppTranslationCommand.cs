using System;
using Acnys.Core.Request;

namespace Swanker.Test.Api.Commands
{
    public class DeleteAppTranslationCommand : Command
    {
        public Guid Id { get; set; }

        public DeleteAppTranslationCommand(Guid id)
        {
            Id = id;
        }
    }
}