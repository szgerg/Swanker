using System.Collections.Generic;

namespace Swanker.Model
{
    public class Parameters
    {
        public string GenericEndpoint { get; set; }
        public string Assembly { get; set; }
        public List<TypeDescriptor> TypeDescriptors { get; set; }
        public string AppName { get; set; }
        public string AppVersion { get; set; }
        public bool AllowSendToGeneric { get; set; }
    }
}