using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Acnys.Core.Request.Abstractions;
using Swanker.Test.Api.Queries;

namespace Swanker.Test.Application.QueryHandlers
{
    public class GetStringListQueryHandler: IHandleQuery<GetStringListQuery, IEnumerable<string>>
    {
        public async Task<IEnumerable<string>> Handle(GetStringListQuery query, IDictionary<string, object> arguments = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return await Task.FromResult(new List<string>{"alma", "korte"});
        }
    }
}
