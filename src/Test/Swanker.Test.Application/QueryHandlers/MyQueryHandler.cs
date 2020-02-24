using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Acnys.Core.Request.Abstractions;
using Swanker.Test.Api.Models;
using Swanker.Test.Api.Queries;

namespace Swanker.Test.Application.QueryHandlers
{
    public class MyQueryHandler : IHandleQuery<MyQuery, IEnumerable<MyQueryHandlerResult>>
    {
        public async Task<IEnumerable<MyQueryHandlerResult>> Handle(MyQuery query, IDictionary<string, object> arguments = null, CancellationToken cancellationToken = new CancellationToken())
        {
            return await Task.FromResult(new List<MyQueryHandlerResult>
            {
                new MyQueryHandlerResult
                {
                    Name = "First",
                    Description = "First desc",
                    Node = new Node
                    {
                        Name = "FN",
                        Childs = new List<Node>
                        {
                            new Node
                            {
                                Name = "SN"
                            }
                        }
                    }
                }
            });
        }
    }
}
