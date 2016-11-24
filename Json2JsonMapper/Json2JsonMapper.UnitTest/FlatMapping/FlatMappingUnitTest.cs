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
        public void FlatMappingUnitTest()
        {
            string exceptedOutput = "{\r\n  \"first\": \"Krishna Kishore\",\r\n  \"last\": \"Bandaru\",\r\n  \"currentAge\": 20,\r\n  \"myheight\": 5.1\r\n}";
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


            Assert.AreEqual<string>(exceptedOutput, ouput.ToString());
        }
    }
}
