using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Acnys.Core.Request.Abstractions;
using Swanker.Test.Api.Commands;

namespace Swanker.Test.Application.CommandHandler
{
    public class ModifyLocationCommandHandler : IHandleCommand<ModifyLocationCommand>
    {
       
        public async Task Handle(ModifyLocationCommand command, IDictionary<string, object> arguments = null, CancellationToken cancellationToken = new CancellationToken())
        {
        }
    }
}
