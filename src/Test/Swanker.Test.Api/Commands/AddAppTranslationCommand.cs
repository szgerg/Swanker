using System;
using Acnys.Core.Request;
using Swanker.Test.Api.Models;

namespace Swanker.Test.Api.Commands
{
    public class AddAppTranslationCommand : Command
    {
        public Guid? Id { get; set; }
        public AppTranslation Atf { get; }

        public AddAppTranslationCommand(AppTranslation atf)
        {
            Atf = atf;
        }
    }
}