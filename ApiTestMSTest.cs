using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ApiTestMSTest
{
    private readonly Api _apiService;

    public ApiTestMSTest()
    {
        var httpClient = new HttpClient();
        _apiService = new Api(httpClient);
    }

   

    [TestMethod]
    public async Task CreateUserWithNullValues_ShouldFail()
    {
       
        var response = await _apiService.CreateUserWithNullValues();

       
        Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [TestMethod]
    public async Task CreateUserWithValidDataAndNullPassword_ShouldFail()
    {
       
        var login = "validLogin";
        var name = "validName";
        var email = "valid@example.com";

       
        var response = await _apiService.CreateUserWithValidDataAndNullPassword(login, name, email);

       
        Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }


   
    [TestMethod]
    public async Task CreatePost_ShouldSucceed()
    {
       
        int userId = 140;
        string message = "string";

       
        var response = await _apiService.CreatePost(userId, message);

       
        Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
    }


   
    [TestMethod]
    public async Task CreatePostWithNullUserIdAndEmptyMessage_ShouldFail()
    {
       
        var response = await _apiService.CreatePostWithNullUserIdAndEmptyMessage();

       
        Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }


   
    [TestMethod]
    public async Task CreatePostWithValidUserIdAndEmptyMessage_ShouldFail()
    {
       
        int userId = 140;
                         

       
        var response = await _apiService.CreatePostWithValidUserIdAndEmptyMessage(userId);

       
        Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

   
    [TestMethod]
    public async Task UpdatePost_ShouldSucceed()
    {
       
        int postId = 76;
        int userId = 140;
        string message = "string";

       
        var response = await _apiService.UpdatePost(postId, userId, message);

       
        Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
    }


   
    [TestMethod]
    public async Task CreateComment_ShouldSucceed()
    {
       
        string message = "Sera que vou passar em qualidade de Software";
        int postId = 76;
        int userId = 140;

       
        var response = await _apiService.CreateComment(message, postId, userId);

       
        Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
    }

}
