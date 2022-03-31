using NUnit.Framework;
using RestApiExample.ApplicationAPI;
using RestApiExample.Models;
using RestApiExample.Utils;
using System.IO;
using System.Net;

namespace RestApiExample.Tests
{
    internal class RestApiExampleTests
    {
        [Test]
        public void RestApiRequestsTests()
        {
            var response1 = ApplicationApi.GetPostsInfo();
            Assert.AreEqual(HttpStatusCode.OK, response1.StatusCode, "Status code is not 200");
            Assert.AreEqual("application/json", response1.ContentType, "Response is not in JSON format");
            Assert.IsTrue(JsonUtil.IsJsonListSortingAscendingById(response1), "Response list is not sorted on ascending (by id)");

            var response2 = ApplicationApi.GetPostsInfo("99");
            Assert.AreEqual(HttpStatusCode.OK, response2.StatusCode, "Status code is not 200");
            var objectPost1 = Deserialization.DeserializeObjectFromResponse<Posts>(response2);
            Assert.AreEqual(10, objectPost1.UserID, "UserId is not equal 10");
            Assert.AreEqual(99, objectPost1.Id, "ID is not equal 99");
            Assert.IsFalse(string.IsNullOrEmpty(objectPost1.Body), "Body is null or empty");
            Assert.IsFalse(string.IsNullOrEmpty(objectPost1.Title), "Title is null or empty");

            var response3 = ApplicationApi.GetPostsInfo("150");
            Assert.AreEqual(HttpStatusCode.NotFound, response3.StatusCode, "Status code is not 404");
            Assert.IsTrue(JsonUtil.IsJsonAfterRequestEmpty(response3), "Response body is not empty");

            string randomTitleText = RandomGenerator.GenerateRandomText(8);
            string randomBodyText = RandomGenerator.GenerateRandomText(15);
            int userId = int.Parse(ConfigUtil.GetValueByName("userId"));
            var expectedPost = new Posts() { Title = randomTitleText, Body = randomBodyText, UserID = userId };
            var response4 = ApplicationApi.CreatePost(expectedPost);
            Assert.AreEqual(HttpStatusCode.Created, response4.StatusCode, "Status code is not 201");
            var actualPost = Deserialization.DeserializeObjectFromResponse<Posts>(response4);
            Assert.AreEqual(expectedPost.Title, actualPost.Title, "Title values are not equal");
            Assert.AreEqual(expectedPost.Body, actualPost.Body, "Body values are not equal");
            Assert.AreEqual(expectedPost.UserID, actualPost.UserID, "UserId values are not equal");
            Assert.IsFalse(string.IsNullOrEmpty(actualPost.Id.ToString()), "Id doesn't exist");

            var response5 = ApplicationApi.GetUsersInfo();
            Assert.AreEqual(HttpStatusCode.OK, response5.StatusCode, "Status code is not 200");
            Assert.AreEqual("application/json", response5.ContentType, "Response is not in JSON format");
            var actualUserId5 = Deserialization.DeserializeObjectFromResponseArray<Users>(response5, 5);
            var expectedUserId5 = Deserialization.DeserializeObjectFromFile<Users>(File.ReadAllText("Resources/user5.json"));
            Assert.IsTrue(expectedUserId5.Equals(actualUserId5), "User with id5 has different data after response №5");

            var response6 = ApplicationApi.GetUsersInfo("5");
            Assert.AreEqual(HttpStatusCode.OK, response6.StatusCode, "Status code is not 200");
            var actualUserId5FromResponse6 = Deserialization.DeserializeObjectFromResponse<Users>(response6);
            Assert.IsTrue(actualUserId5.Equals(actualUserId5FromResponse6), "User with id5 has different data after response №6");
        }
    }
}