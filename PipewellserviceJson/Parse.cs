using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceJson
{
    public class JsonHelper
    {
        public static async Task<T> Convert<T, Y>(Y input)
        {
            return  JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(input));
        }
        public static  T Convert2<T, Y>(Y input)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(input));
        }
        //public async Task<T> Convert<T, Y>(Y input)
        //{
        //    return JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(input));
        //}
    }
}
