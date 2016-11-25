using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json2JsonMapper.Transformation
{
    public class TransformationFuncs
    {
        public static string ApplyFunction(string funcName,JObject doc)        
        {
            if (funcName.ToLower().StartsWith("@Concat".ToLower()))
            {
               

                List<string> parmeters = resolveParameters(doc, retriveParameters(funcName));

                return concate(parmeters);
            }
            else
            {
                return string.Empty;
            }
                        
        }

        private static string concate(List<string> param)
        {

            StringBuilder builder = new StringBuilder();
            foreach (String s in param)
            {
                builder.Append(s);
            }
            return builder.ToString();
        }

        public static string retriveParameters(string JPathstr)
        {
            int startIndex = JPathstr.IndexOf('(');
            int endIndex = JPathstr.IndexOf(')');

            int strlen = JPathstr.Length;

            return JPathstr.Substring(startIndex + 1, strlen - startIndex - 2);
        }

        public static List<string> resolveParameters(JObject input ,string JPathstr)
        {
            string[] JsonPath = JPathstr.Split(',');

            List<string> outputstr = new List<string>();

            foreach(string str in JsonPath)
            {
                if(str.StartsWith("$"))
                {
                    JToken ouput = input.SelectToken(str);
                    outputstr.Add(ouput.Value<string>());
                }
                else
                {
                    outputstr.Add(str);
                }
                
            }
            return outputstr;
       

        }

 
    }
}
