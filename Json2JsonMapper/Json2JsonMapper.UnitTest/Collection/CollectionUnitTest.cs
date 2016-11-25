using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Json2JsonMapper.UnitTest
{
    [TestClass]
    public class CollectionUnitTests
    {
        [TestMethod]
        public void CollectionUnitTest()
        {
            string ExceptedOutPut = "{\r\n  \"first\": \"Krishna Kishore\",\r\n  \"last\": \"Bandaru\",\r\n  \"currentAge\": 20,\r\n  \"myheight\": 5.1,\r\n  \"myaddress\": [\r\n    {\r\n      \"myaddressLine1\": \"FirstLine1\",\r\n      \"myaddressLine2\": \"FirstLine2\",\r\n      \"myphone\": \"8175111122345\",\r\n      \"mylandline\": \"near by apprt4\",\r\n      \"mycity\": \"Hyderabad\",\r\n      \"mystate\": \"Telengana\",\r\n      \"mycountry\": \"India\",\r\n      \"mypincode\": \"589001\",\r\n      \"isReal\": true,\r\n      \"ismyReal\": \"True\",\r\n      \"isNo\": \"12345\"\r\n    },\r\n    {\r\n      \"myaddressLine1\": \"FirstLine3\",\r\n      \"myaddressLine2\": \"FirstLine4\",\r\n      \"myphone\": \"917511112456\",\r\n      \"mylandline\": \"near by apprt1\",\r\n      \"mycity\": \"Chennai\",\r\n      \"mystate\": \"TamilNadu\",\r\n      \"mycountry\": \"India\",\r\n      \"mypincode\": \"589001\",\r\n      \"isReal\": true,\r\n      \"ismyReal\": \"True\",\r\n      \"isNo\": \"12345\"\r\n    },\r\n    {\r\n      \"myaddressLine1\": \"FirstLine5\",\r\n      \"myaddressLine2\": \"FirstLine6\",\r\n      \"myphone\": \"7175111123567\",\r\n      \"mylandline\": \"near by apprt6\",\r\n      \"mycity\": \"Bangalore\",\r\n      \"mystate\": \"Karnataka\",\r\n      \"mycountry\": \"India\",\r\n      \"mypincode\": \"589001\",\r\n      \"isReal\": true,\r\n      \"ismyReal\": \"True\",\r\n      \"isNo\": \"12345\"\r\n    }\r\n  ]\r\n}";
            StreamReader re = new StreamReader(@"Collection\CollectionsMapping.json");
            StreamReader re1 = new StreamReader(@"Collection\CollectionsInput.json");
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
            Assert.AreEqual<string>(ExceptedOutPut, ouput.ToString());

        }

        [TestMethod]
        public void CollectionwithHierarchyUnitTest()
        {
            string ExceptedOutPut = "{\r\n  \"customerId\": \"1234567890\",\r\n  \"customerName\": \"Krishna Kishore\",\r\n  \"myorders\": [\r\n    {\r\n      \"myorderAt\": \"04/22/2012 04:55:43\",\r\n      \"myorderId\": \"0000001-00001\",\r\n      \"myordersitems\": [\r\n        {\r\n          \"myitemId\": \"00001\",\r\n          \"myorderId\": \"Item Descrption 1\",\r\n          \"myquantity\": 4,\r\n          \"mytotalItemCost\": 800,\r\n          \"myitemCost\": 200\r\n        },\r\n        {\r\n          \"myitemId\": \"00002\",\r\n          \"myorderId\": \"Item Descrption 2\",\r\n          \"myquantity\": 3,\r\n          \"mytotalItemCost\": 630,\r\n          \"myitemCost\": 210\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \"myorderAt\": \"04/22/2012 04:55:43\",\r\n      \"myorderId\": \"0000001-00002\",\r\n      \"myordersitems\": [\r\n        {\r\n          \"myitemId\": \"00003\",\r\n          \"myorderId\": \"Item Descrption 3\",\r\n          \"myquantity\": 4,\r\n          \"mytotalItemCost\": 800,\r\n          \"myitemCost\": \"200\"\r\n        },\r\n        {\r\n          \"myitemId\": \"00004\",\r\n          \"myorderId\": \"Item Descrption 4\",\r\n          \"myquantity\": 3,\r\n          \"mytotalItemCost\": 630,\r\n          \"myitemCost\": 210\r\n        }\r\n      ]\r\n    },\r\n    {\r\n      \"myorderAt\": \"04/22/2012 04:55:43\",\r\n      \"myorderId\": \"0000001-00003\",\r\n      \"myordersitems\": [\r\n        {\r\n          \"myitemId\": \"00001\",\r\n          \"myorderId\": \"Item Descrption 1\",\r\n          \"myquantity\": 2,\r\n          \"mytotalItemCost\": 400,\r\n          \"myitemCost\": 200\r\n        },\r\n        {\r\n          \"myitemId\": \"00002\",\r\n          \"myorderId\": \"Item Descrption 2\",\r\n          \"myquantity\": 2,\r\n          \"mytotalItemCost\": 420,\r\n          \"myitemCost\": 210\r\n        }\r\n      ]\r\n    }\r\n  ]\r\n}";
            StreamReader re = new StreamReader(@"Collection\OrderCollectionsMapping.json");
            StreamReader re1 = new StreamReader(@"Collection\OrderCollectionsInput.json");
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
            Assert.AreEqual<string>(ExceptedOutPut, ouput.ToString());

        }
    }
}
