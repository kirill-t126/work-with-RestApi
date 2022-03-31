using Newtonsoft.Json;
using RestApiExample.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApiExample.Utils
{
    internal static class JsonUtil
    {
        public static bool IsJsonListSortingAscendingById(RestResponse response)
        {
            List<Posts> listAfterResponse = JsonConvert.DeserializeObject<List<Posts>>(response.Content);
            List<Posts> sortedList = listAfterResponse.OrderBy(obj => obj.Id).ToList();
            return listAfterResponse.SequenceEqual(sortedList);
        }

        public static bool IsJsonAfterRequestEmpty(RestResponse response)
        {
            return response.Content == "{}";
        }
    }
}