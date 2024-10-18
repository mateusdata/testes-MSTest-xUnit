using System;
using System.Threading.Tasks;
using Xunit;

public class ApiTestXUnit
{
    private readonly Api _apiService;

    public ApiTestXUnit()
    {
        var httpClient = new HttpClient();
        _apiService = new Api(httpClient);
    }

  

    [Fact]
    public async Task CreateUser_ShouldCreateNewUser()
    {
        var randomEmail = $"user{new Random().Next(1000, 9999)}@example.com";
        await _apiService.CreateUser("newuser", "New User", randomEmail, "password123");
    }

    [Fact]
    public async Task UpdateUser_ShouldUpdateExistingUser()
    {
      
        string userId = "2";
        await _apiService.UpdateUser(userId, "updateduser", "Updated User", "updated@example.com", "newpassword123");
    }

    [Fact]
    public async Task GetUsers_ShouldFetchUsers()
    {
        await _apiService.GetUsers();
    }

    [Fact]
    public async Task GetUserById_ShouldFetchUser()
    {
      
        string userId = "2";
        await _apiService.GetUserById(userId);
    }

    [Fact]
    public async Task DeleteUser_ShouldDeleteUser()
    {
      
        string userId = "2";
        await _apiService.DeleteUser(userId);
    }

  

    [Fact]
    public async Task Login_ShouldFailWithEmptyEmail()
    {
      
        var invalidEmail = "";
        var password = "123456";
        
      
        var response = await _apiService.Login(invalidEmail, password);

      
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

  

    [Fact]
    public async Task Login_ShouldFailWithShortPassword()
    {
      
        var validEmail = "validuser@example.com";
        var shortPassword = "1234";
        
      
        var response = await _apiService.Login(validEmail, shortPassword);

      
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

  

    [Fact]
    public async Task Login_ShouldFailWithEmptyEmailAndPassword()
    {
      
        var emptyEmail = "";
        var emptyPassword = "";
        
      
        var response = await _apiService.Login(emptyEmail, emptyPassword);

      
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }
}
