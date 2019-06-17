using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace IOHelper
{
    public class JsonHelper
    {
        public static JObject Read(string jsonfile)
        {
            using (System.IO.StreamReader file = System.IO.File.OpenText(jsonfile))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);

                    return o;
                }
            }
        }

        public static List<T> Json2List<T>(string json)
        {
            JavaScriptSerializer Serializers = new JavaScriptSerializer();
            List<T> list = Serializers.Deserialize<List<T>>(json);

            return list;
        }
    }
}
