using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using Newtonsoft.Json;
using System.Collections;

namespace RestClient
{
    public class jsonHelper
    {
        public static IList<T> From<T>(string json)
        {  
            IList<T> list = new List<T>(); 
            JsonTextReader reader = new JsonTextReader(new StringReader(json));
            reader.SupportMultipleContent = true;

            while (true)
            {
                if (!reader.Read())
                {
                    break;
                }

                T obj = Activator.CreateInstance<T>();
                JsonSerializer serializer = new JsonSerializer();
                list = serializer.Deserialize<List<T>>(reader);
             
            }
            return list;
        }
    }
}
