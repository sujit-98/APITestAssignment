using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace APITestAssignment.APIHelper
{
    public static class HandelData
    {
        public static T GetContent<T>(RestResponse response)

        {
            var content = response.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }

        public static string SerializeJsonString(dynamic payload)
        {
            return JsonConvert.SerializeObject(payload, Formatting.Indented);
        }
    }
}
