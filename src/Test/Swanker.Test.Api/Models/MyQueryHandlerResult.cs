using System;
using System.Collections.Generic;
using System.Text;

namespace Swanker.Test.Api.Models
{
    public class MyQueryHandlerResult
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Node Node { get; set; }
    }

    public class Node
    {
        public string Name { get; set; }
        public List<Node> Childs { get; set; }
    }
}
