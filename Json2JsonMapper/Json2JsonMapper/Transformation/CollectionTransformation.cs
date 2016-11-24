using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json2JsonMapper.Transformation
{
    public class CollectionTransform : ITransform
    {
        Mapping _mapping;
        public CollectionTransform(Mapping mapping)
        {
            _mapping = mapping;
        }
        public void Transform(JObject input, ref JObject output)
        {
            
            IEnumerable<JToken> collecionItems = input.SelectTokens(_mapping.SourcePropertyName);

            // ITransform trasns = TranformationFactory.GetTransforamtion(map.Type, map);

            JArray array = new JArray();

            foreach (var item in collecionItems)
            {
                JObject innerinput = (JObject)item;
                JObject innerouput = new JObject();

                foreach (var map in _mapping.Mappings)
                {
                    ITransform trasns = TranformationFactory.GetTransforamtion(map.Type, map);
                    trasns.Transform(innerinput, ref innerouput);
                }

                array.Add(innerouput);
            }

            output.Add(_mapping.DestPropertyName, array);

        }
    }
}
