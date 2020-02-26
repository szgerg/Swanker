using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Acnys.Core.Request.Abstractions;
using Swanker.Test.Api.Commands;

namespace Swanker.Test.Application.CommandHandler
{
    public class AddAppTranslationCommandHandler : IHandleCommand<AddAppTranslationCommand>
    {

        public async Task Handle(AddAppTranslationCommand command, IDictionary<string, object> arguments = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
        }
    }
}