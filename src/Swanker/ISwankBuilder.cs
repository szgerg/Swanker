using System;
using System.Collections.Generic;
using System.Reflection;

namespace Swanker
{
    public interface ISwankBuilder
    {
        Assembly Assembly { get; set; }
        List<Type> Types { get; set; }
        string GenericEndpoint { get; set; }
        string AppName { get; set; }
        string AppVersion { get; set; }
        bool AllowSendToGeneric { get; set; } 
    }
}
