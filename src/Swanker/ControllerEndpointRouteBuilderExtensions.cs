using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Swanker
{
    public static class ControllerEndpointRouteBuilderExtensions
    {
        public static IEndpointRouteBuilder MapSwankController(this IEndpointRouteBuilder endpoints, string root)
        {
            if (endpoints == null)
            {
                throw new ArgumentNullException(nameof(endpoints));
            }
            endpoints.MapControllerRoute("genericswank", root + "/{controller=SwankGeneric}/{action=gethtml}");
            endpoints.MapControllerRoute("genericswankparameters", root + "/parameters/{controller=SwankGeneric}/{action=getparameters}");
            endpoints.MapControllerRoute("genericswankdetails", root + "/details/{controller=SwankGeneric}/{action=getdetails}");

            return endpoints;
        }
    }
}
