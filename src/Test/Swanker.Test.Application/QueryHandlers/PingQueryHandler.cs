using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Acnys.Core.Request.Abstractions;
using Swanker.Test.Api.Queries;

namespace Swanker.Test.Application.QueryHandlers
{
    public class PingQueryHandler : IHandleQuery<Ping, string>
    {
        public async Task<string> Handle(Ping query, IDictionary<string, object> arguments, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult("Pong");
        }
    }
}
