using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace Swanker
{
    public class SwankBuilder: ISwankBuilder
    {
        [JsonIgnore]
        public Assembly Assembly { get; set; }
        public List<Type> Types { get; set; }
        public string GenericEndpoint { get; set; }
        public string AppName { get; set; }
        public string AppVersion{ get; set; }
        public bool AllowSendToGeneric { get; set; } = true;
        public Type QueryGenericInterface { get; set; }
        public Assembly QueryGenericInterfaceAssembly { get; set; }
    }
}