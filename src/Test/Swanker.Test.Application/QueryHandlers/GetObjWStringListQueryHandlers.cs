using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Acnys.Core.Request.Abstractions;
using Swanker.Test.Api.Models;
using Swanker.Test.Api.Queries;

namespace Swanker.Test.Application.QueryHandlers
{
    public class GetObjWStringListQueryHandlers: IHandleQuery<GetObjWStringListQuery, ObjWStringList>
    {
        public async Task<ObjWStringList> Handle(GetObjWStringListQuery query, IDictionary<string, object> arguments = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return await Task.FromResult(new ObjWStringList
            {
                Strings = new List<string> { "sziva", "banan"}
            });
        }
    }
}
