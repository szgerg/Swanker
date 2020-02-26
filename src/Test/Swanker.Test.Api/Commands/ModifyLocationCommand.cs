using Acnys.Core.Request;
using Swanker.Test.Api.Models;

namespace Swanker.Test.Api.Commands
{
    public class ModifyLocationCommand : Command
    {
        public Location Location { get; }

        public ModifyLocationCommand(Location location)
        {
            this.Location = location;
        }
    }
}
