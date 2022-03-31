using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace RestApiExample.Utils
{
    internal static class Deserialization
    {
        public static T DeserializeObjectFromResponse<T>(RestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public static T DeserializeObjectFromResponseArray<T>(RestResponse response, int objectNumber)
        {
            return JsonConvert.DeserializeObject<List<T>>(response.Content)[objectNumber - 1];
        }

        public static T DeserializeObjectFromFile<T>(string filePath)
        {
            return JsonConvert.DeserializeObject<T>(filePath);
        }
    }
}