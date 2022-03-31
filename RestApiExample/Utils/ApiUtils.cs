using RestSharp;

namespace RestApiExample.Utils
{
    internal static class ApiUtils
    {
        public static RestResponse SendGetRequest(string testURL, string endpoint)
        {
            var client = new RestClient(testURL);
            var request = new RestRequest(endpoint, Method.Get);
            return client.ExecuteAsync(request).Result;
        }

        public static RestResponse SendPostRequest(string testURL, string endpoint, object someModel)
        {
            var client = new RestClient(testURL);
            var request = new RestRequest($"{endpoint}", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(someModel);
            var response = client.ExecuteAsync(request).Result;
            return response;
        }
    }
}