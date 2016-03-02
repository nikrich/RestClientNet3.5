using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace RestClient
{
    public class apiHelper
    {
        //Take in 3 params
        // string URL               - Base URL for the api
        // string resource          - Resource being consumed, eg person, person/vehicle, person/record, etc
        // Dictionary parameters    - Parameters to be passed
        public static string Get(string URL, string resource, Dictionary<string, string> parameters)
        {
            int idx = 0;
            string queryStr = "";
            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                switch (idx)
                {
                    case 0: queryStr += "?" + parameter.Key + "=" + parameter.Value; break;
                    default: queryStr += "&" + parameter.Key + "=" + parameter.Value; break;
                }

                idx++;
            }

            WebRequest webRequest = WebRequest.Create(URL + resource + queryStr);
            WebResponse webResp = webRequest.GetResponse();
            Stream receiveStream = webResp.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");

            StreamReader readStream = new StreamReader(receiveStream, encode);
            Char[] read = new Char[256];
            int count = readStream.Read(read, 0, 256);

            StringBuilder strBuilder = new StringBuilder();

            while (count > 0)
            {
                // Dump the 256 characters on a string and display the string onto the console.                
                strBuilder.Append(new String(read, 0, count));
                count = readStream.Read(read, 0, 256);
            }

            return strBuilder.ToString();
        }
    }
}
