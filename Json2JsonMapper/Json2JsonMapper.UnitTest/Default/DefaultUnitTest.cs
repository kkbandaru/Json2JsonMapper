using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Json2JsonMapper.UnitTest.Default
{
    [TestClass]
    public class DefaultUnitTest
    {
        

        [TestMethod]
        public void DefaultValueUnitTest()
        {
            string exceptedOutput = "{\r\n  \"first\": \"Krishna Kishore\",\r\n  \"last\": \"Krishna Kishore''Bandaru\",\r\n  \"currentAge\": 20,\r\n  \"myheight\": 5.1\r\n}";
            StreamReader re = new StreamReader(@"Default\DefaultMapping.json");
            StreamReader re1 = new StreamReader(@"Default\DefaultMappingInput.json");
            JObject mapping = new JObject();
            JObject mappingInput = new JObject();

            using (JsonTextReader reader = new JsonTextReader(re))
            {
                mapping = JObject.Load(reader);

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
