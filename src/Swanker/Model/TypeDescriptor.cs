using System.Collections.Generic;

namespace Swanker.Model
{
    public class TypeDescriptor
    {
        public string Namespace { get; set; }
        public List<string> Names { get; } = new List<string>();
    }
}