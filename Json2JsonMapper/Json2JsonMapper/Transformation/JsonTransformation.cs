using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json2JsonMapper.Transformation
{
    public class JsonTransformation : ITransform
    {
        private JsonMapping _mapping;
        public JsonTransformation(JsonMapping mapping)
        {
            _mapping = mapping;
        }
        public void Transform(JObject input, ref JObject output)
        {

            foreach(var map in _mapping.Mappings)
            {
                ITransform trasns = TranformationFactory.GetTransforamtion(map.Type,map);
                 trasns.Transform(input, ref output);
            }


        }
    }
}
