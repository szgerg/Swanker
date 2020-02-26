using System;
using System.Collections.Generic;

namespace Swanker.Test.Api.Models
{
    public class AppTranslation
    {
        public Guid Id { get; set; }
        public Guid BasedOn { get; set; }
        public string AppName { get; set; }
        public string AppVersion { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public bool IsDraft { get; set; }
        public List<KeyValuePair<string,string>> Translation { get; set; }
    }
}