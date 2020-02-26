using Acnys.Core.Request;
using Swanker.Test.Api.Models;

namespace Swanker.Test.Api.Commands
{
    public class UpdateAppTranslationCommand : Command
    {
        public AppTranslation Atf { get; }

        public UpdateAppTranslationCommand(AppTranslation atf)
        {
            Atf = atf;
        }
    }
}