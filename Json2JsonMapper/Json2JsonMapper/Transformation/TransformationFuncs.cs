using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json2JsonMapper.Transformation
{
    public class TransformationFuncs
    {
        public static object ApplyFunction(string funcName, string[] param)        
        {
            if (funcName.ToLower() == "Concat".ToLower())
            {
                return concate(param);
            }
            else
            {
                return string.Empty;
            }
                        
        }

        private static string concate(string[] param)
        {
            return null;
        }

 
    }
}
