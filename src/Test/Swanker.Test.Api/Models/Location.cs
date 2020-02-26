using System;

namespace Swanker.Test.Api.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CouchDbUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
