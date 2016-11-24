using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json2JsonMapper.Transformation
{
    public class TranformationFactory
    {
        public static ITransform GetTransforamtion(string type,Mapping mapping)
        {
            if(type.ToLower()=="single".ToLower())
            {
                return new SignleValueTransform(mapping);
            }
            else if (type.ToLower() == "collection".ToLower())
            {
                return new CollectionTransform(mapping);
            }
            else
            {
                return null;
            }
        }
    }
}
