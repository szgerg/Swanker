using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Acnys.Core.Request.Abstractions;
using Swanker.Test.Api.Commands;

namespace Swanker.Test.Application.CommandHandler
{
    public class UpdateAppTranslationCommandHandler : IHandleCommand<UpdateAppTranslationCommand>
    {
        
        public async Task Handle(UpdateAppTranslationCommand command, IDictionary<string, object> arguments = null, CancellationToken cancellationToken = new CancellationToken())
        {
        }
    }
}