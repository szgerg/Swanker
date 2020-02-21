using System;
using Microsoft.Extensions.DependencyInjection;

namespace Swanker
{
    public static class SwankServiceCollectionExtensions
    {
        public static IServiceCollection AddSwank(this IServiceCollection services, Action<ISwankBuilder> configure)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));

            }

            var res =  services.AddSingleton<ISwankBuilder>((services) =>
            {
                var sb = new SwankBuilder();
                configure.Invoke(sb);
                return sb;
            });

            return res;
        }
    }
}
