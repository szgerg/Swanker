using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Acnys.Core.Request.Abstractions;
using Swanker.Test.Api.Commands;

namespace Swanker.Test.Application.CommandHandler
{
    public class DeleteLocationCommandHandler : IHandleCommand<DeleteLocationCommand>
    {
        public async Task Handle(DeleteLocationCommand command, IDictionary<string, object> arguments = null, CancellationToken cancellationToken = new CancellationToken())
        {
        }
    }
}
