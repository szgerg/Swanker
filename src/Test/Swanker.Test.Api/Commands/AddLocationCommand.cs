using Acnys.Core.Request;
using Swanker.Test.Api.Models;

namespace Swanker.Test.Api.Commands
{
    public class AddLocationCommand : Command
    {
        public Location Location { get; }

        public AddLocationCommand(Location location)
        {
            this.Location = location;
        }
    }
}
