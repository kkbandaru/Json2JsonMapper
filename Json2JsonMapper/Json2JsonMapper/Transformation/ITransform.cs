using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json2JsonMapper.Transformation
{
    public interface ITransform
    {
        void Transform(JObject input, ref JObject ouput);
    }
}
