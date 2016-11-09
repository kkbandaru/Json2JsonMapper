using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json2JsonMapper
{
    public class JsonMapping
    {
        public string Name { get; set; }

        public List<Mapping> Mappings { get; set; }
    }

    public class Mapping
    {
        public string SourcePropertyName { get; set; }
        public string DestPropertyName { get; set; }

        public string DataType { get; set; }

        public string Type { get; set; }
    }
}
