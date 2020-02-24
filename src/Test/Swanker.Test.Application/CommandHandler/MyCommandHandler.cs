using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Acnys.Core.Request.Abstractions;
using Swanker.Test.Api.Commands;

namespace Swanker.Test.Application.CommandHandler
{
    public class MyCommandHandler: IHandleCommand<MyCommand>
    {
        public async Task Handle(MyCommand command, IDictionary<string, object> arguments = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            await Task.Run(() => { });
        }
    }
}
