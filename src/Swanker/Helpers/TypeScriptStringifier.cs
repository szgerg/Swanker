using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace Swanker.Helpers
{
    internal class TypeScriptStringifier : StringifierBase
    {
        private readonly ILogger _logger;
        private List<Type> _types = new List<Type>();

        public TypeScriptStringifier(ILogger logger)
        {
            _logger = logger;
        }

        public List<string> Stringify(Type type, int tab)
        {
            var list = new List<string>();

            if (_types.Contains(type))
            {
                _logger.Debug($"Type: {type.FullName}, already TS stringed");
                return list;
            }

            _types.Add(type);

            var et = type.GetInterfaces().FirstOrDefault(i => i == typeof(IEnumerable));
            if (et != null)
            {
                var it = type.GenericTypeArguments[0];

                if (_types.Contains(it))
                {
                    _logger.Debug($"Type: {type.FullName}, already TS stringed");
                    return list;
                }

                list.Add($"{tb(tab)}Result type: {it.Name} []{rn}");

                list.AddRange(Stringify(it, tab));

                return list;
            }

            var res = $"{tb(tab)}export interface {type.Name} {{{rn}";

            var ps = type.GetProperties().Where(p => p.CanWrite);

            foreach (var pi in ps)
            {
                _logger.Debug($"Property Name: {pi.Name}, Type: {pi.PropertyType} TS stringing.");

                if (TypeHelper.IsNumericType(pi.PropertyType))
                    res += $"{tb(tab + 1)}{pi.Name.f2l()}: number;{rn}";
                else if (pi.PropertyType == typeof(string))
                    res += $"{tb(tab + 1)}{pi.Name.f2l()}: string;{rn}";
                else if (pi.PropertyType == typeof(Guid))
                    res += $"{tb(tab + 1)}{pi.Name.f2l()}: string;{rn}";
                else if (pi.PropertyType.GetInterfaces().Any(i => i.Name == typeof(IEnumerable).Name))
                {
                    res += $"{tb(tab + 1)}{pi.Name.f2l()}: {pi.PropertyType.GetGenericArguments().FirstOrDefault().Name}[];{rn}";

                    list.AddRange(Stringify(pi.PropertyType.GetGenericArguments().FirstOrDefault(), 0));
                }
                else if (pi.PropertyType.IsClass)
                {
                    res += $"{tb(tab + 1)}{pi.Name.f2l()}: {pi.PropertyType.Name};{rn}";

                    list.AddRange(Stringify(pi.PropertyType, 0));
                }
            }

            if (!ps.Any())
                res = res.Substring(0, res.Length - 2);

            res += $"{tb(tab)}}}";

            list.Insert(0, res);

            return list;
        }

        
    }
}
