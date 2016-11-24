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
            JToken value;
            if (_mapping.SourcePropertyName.StartsWith("$"))
            {
                value = input.SelectToken(_mapping.SourcePropertyName);
            }
            else
            {
                value = input[_mapping.SourcePropertyName];
            }

            if (_mapping.DataType.ToLower() == "string")
            {
                output[_mapping.DestPropertyName] =  value.Value<string>(); 
            }
            else if (_mapping.DataType.ToLower() == "int")
            {
                output[_mapping.DestPropertyName] = value.Value<int>(); 
            }
            else if (_mapping.DataType.ToLower() == "decimal")
            {
                output[_mapping.DestPropertyName] = value.Value<decimal>(); 
            }
            else if (_mapping.DataType.ToLower() == "bool")
            {
                output[_mapping.DestPropertyName] =  value.Value<bool>() ;
            }
            else
            {
                output[_mapping.DestPropertyName] = value;
            }
        }
    }
}
