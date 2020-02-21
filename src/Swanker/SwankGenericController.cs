using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using Swanker.Helpers;
using Swanker.Model;

namespace Swanker
{
    [Produces("application/json")]
    public class SwankGenericController : ControllerBase
    {
        private readonly ISwankBuilder _swankBuilder;
        private readonly ILogger _logger;
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };

        public SwankGenericController(ISwankBuilder swankBuilder, ILogger logger)
        {
            _swankBuilder = swankBuilder;
            _logger = logger;
        }

        [HttpGet]
        public async Task<Details> GetDetails(string name, bool typeHeader, CancellationToken cancellationToken = default)
        {
            var t = _swankBuilder.Assembly.GetTypes().FirstOrDefault(t => t.FullName == name);

            _logger.Debug($"GetDetails: {t?.FullName}");

            var json = new JsonStringifier(_logger).Stringify(t, 0, !typeHeader, $"{t.FullName},{_swankBuilder.Assembly.GetName().Name}");
            var ts = "";
            new TypeScriptStringifier(_logger).Stringify(t, 0).ForEach(i => ts += i + "\r\n");


            return await Task.FromResult(new Details { Assembly = _swankBuilder.Assembly.GetName().Name, Json = json, TypeScript = ts});
        }

       

        [HttpGet]
        public async Task<ContentResult> GetHtml(CancellationToken cancellationToken = default)
        {
            var loc = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            using (var fr = System.IO.File.OpenText($"{loc}/swanker.html"))
            {
                var res = await fr.ReadToEndAsync();

                return base.Content(res, "text/html");
            }
        }

        [HttpGet]
        public async Task<string> GetParameters(CancellationToken cancellationToken = default)
        {
            var res = await Task.FromResult(JsonConvert.SerializeObject(new Parameters
            {
                GenericEndpoint = _swankBuilder.GenericEndpoint,
                TypeDescriptors = GetTypes(),
                AppName = _swankBuilder.AppName,
                AppVersion = _swankBuilder.AppVersion,
                Assembly = _swankBuilder.Assembly.GetName().Name,
                AllowSendToGeneric = _swankBuilder.AllowSendToGeneric
            }, Formatting.Indented));
            return res;
        }

        private List<TypeDescriptor> GetTypes()
        {
            var res = new List<TypeDescriptor>();

             var types = _swankBuilder.Assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => _swankBuilder.Types.Any(t => t.Name == i.Name))).ToList();

             types.ForEach(t =>
             {
                 var td = res.FirstOrDefault(i => i.Namespace == t.Namespace);

                 if (td == null)
                 {
                     td = new TypeDescriptor
                     {
                         Namespace = t.Namespace
                     };

                     res.Add(td);
                 }

                 td.Names.Add(t.Name);
             });

             return res;
        }
    }
}
