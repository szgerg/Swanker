using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Serilog;

namespace Swanker.Helpers
{
    internal class JsonStringifier: StringifierBase
    {
        private readonly ILogger _logger;
        private List<Type> _types = new List<Type>();

        public JsonStringifier(ILogger logger)
        {
            _logger = logger;
        }

        public string Stringify(Type type, int tab, bool typeBody, string s = null)
        {
            var res = "";

            if (_types.Contains(type))
            {
                _logger.Debug($"Type: {type.FullName}, already JSON stringed");
                return $"{tb(tab)}{{...}}";
            }

            var t = type.GetInterfaces().FirstOrDefault(i => i == typeof(IEnumerable));
            if (t != null)
                return "";

            _types.Add(type);

                res += $"{tb(tab)}{{{rn}";

            var ps = type.GetProperties().Where(p => p.CanRead);

            if (s != null && typeBody)
                res += $"{tb(tab + 1)}\"$type\": \"{s}\",{rn}";

            foreach (var pi in ps)
            {
                _logger.Debug($"Property Name: {pi.Name}, Type: {pi.PropertyType} JSON stringing.");

                if (TypeHelper.IsNumericType(pi.PropertyType))
                    res += $"{tb(tab + 1)}\"{pi.Name}\": 0,{rn}";
                else if (pi.PropertyType == typeof(string))
                    res += $"{tb(tab + 1)}\"{pi.Name}\": \"string\",{rn}";
                else if (pi.PropertyType == typeof(Guid))
                    res += $"{tb(tab + 1)}\"{pi.Name}\": \"{Guid.Empty}\",{rn}";
                else if (pi.PropertyType.GetInterfaces().Any(i => i.Name == typeof(IEnumerable).Name))
                {
                    res += $"{tb(tab + 1)}\"{pi.Name}\": [{rn}{Stringify(pi.PropertyType.GetGenericArguments().FirstOrDefault(), tab + 2, typeBody)}{rn}{tb(tab + 1)}],{rn}";
                }
                else if (pi.PropertyType.IsClass)
                    res += $"{tb(tab + 1)}\"{pi.Name}\":{Stringify(pi.PropertyType, tab + 1, typeBody)},{rn}";
            }

            if (ps.Any() || (s != null && typeBody))
                res = res.Substring(0, res.Length - 3);

            res += $"{rn}{tb(tab)}}}";

            if (!ps.Any() && !typeBody)
                res = $"{tb(tab)}{{}}";

            return res;
        }
    }
}
