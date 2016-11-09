using Json2JsonMapper.Transformation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json2JsonMapper
{
    public class AutoMapper
    {
        private JsonMapping _mappingFile;
        private JsonTransformation transform;
        public JsonMapping MappingFile
        {
            get
            {
                return _mappingFile;
            }
            
        }

        public AutoMapper(string mapping)
        {
            _mappingFile = JsonConvert.DeserializeObject<JsonMapping>(mapping);
            
            transform = new JsonTransformation(_mappingFile);
        }


        public AutoMapper(JObject mapping)
        {
            
            _mappingFile = mapping.ToObject<JsonMapping>(); 

            transform = new JsonTransformation(_mappingFile);
        }

        public JObject Transform(JObject input)
        {
            JObject output = new JObject();

            transform.Transform(input, ref output);

            return output;
        }


    }
}
