using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json2JsonMapper.Transformation
{
    public class SignleValueTransform : ITransform
    {
        Mapping _mapping;
        public SignleValueTransform(Mapping mapping)
        {
            _mapping = mapping;
        }
        public void Transform(JObject input, ref JObject output)
        {
            output[_mapping.DestPropertyName] = input[_mapping.SourcePropertyName];
        }
    }
}
