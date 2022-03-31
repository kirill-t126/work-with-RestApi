using RestApiExample.Models;
using RestApiExample.Utils;
using RestSharp;

namespace RestApiExample.ApplicationAPI
{
    internal static class ApplicationApi
    {
        public static RestResponse GetPostsInfo(string postId = "")
        {
            if (string.IsNullOrEmpty(postId))
            {
                return ApiUtils.SendGetRequest(ConfigUtil.GetValueByName("testURL"), "posts");
            }
            else
            {
                return ApiUtils.SendGetRequest(ConfigUtil.GetValueByName("testURL"), $"posts/{postId}");
            }
        }

        public static RestResponse CreatePost(Posts testPost)
        {
            return ApiUtils.SendPostRequest(ConfigUtil.GetValueByName("testURL"), "posts", testPost);
        }

        public static RestResponse GetUsersInfo(string userId = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                return ApiUtils.SendGetRequest(ConfigUtil.GetValueByName("testURL"), "users");
            }
            else
            {
                return ApiUtils.SendGetRequest(ConfigUtil.GetValueByName("testURL"), $"users/{userId}");
            }
        }
    }
}