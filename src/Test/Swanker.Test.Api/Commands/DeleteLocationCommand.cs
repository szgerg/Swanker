using System;
using Acnys.Core.Request;

namespace Swanker.Test.Api.Commands
{
    public class DeleteLocationCommand : Command
    {
        public Guid LocationId { get; set; }

        public DeleteLocationCommand(Guid locationId)
        {
            this.LocationId = locationId;
        }
    }
}
