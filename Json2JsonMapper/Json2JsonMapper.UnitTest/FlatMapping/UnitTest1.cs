using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Json2JsonMapper.UnitTest
{
    [TestClass]
    public class FlatMapping
    {
        [TestMethod]
        public void TestMethod1()
        {
            StreamReader re = new StreamReader(@"FlatMapping\FlatMapping.json");
            StreamReader re1 = new StreamReader(@"FlatMapping\FlatMappingInput.json");
            JObject mapping = new JObject();
            JObject mappingInput = new JObject();

            using (JsonTextReader reader = new JsonTextReader(re))
            {
                mapping =  JObject.Load(reader);
              
            }

            using (JsonTextReader reader = new JsonTextReader(re1))
            {
                mappingInput = JObject.Load(reader);

            }

            AutoMapper mapper = new AutoMapper(mapping);

            JObject ouput = mapper.Transform(mappingInput);

        }
    }
}
