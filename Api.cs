using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class Api
{
    private readonly HttpClient _httpClient;
    private readonly string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im1hdGV1c0BnbWFpbC5jb20iLCJ1c2VyIjoyLCJpYXQiOjE3MjkyMTQ0NzAsImV4cCI6MTczMDUxMDQ3MH0.D2ehbFtVLGHqJRhF2purLVHsO2e5BXNjbF8CKJtm61M";

    public Api(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

   
    public async Task CreateUser(string login, string name, string email, string password)
    {
        var userData = new
        {
            login,
            name,
            email,
            password
        };

        var content = new StringContent(JsonSerializer.Serialize(userData), Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.mateusdata.com.br/users");
        request.Content = content;
        request.Headers.Add("Authorization", $"Bearer {_token}");

        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
        }
        else
        {
            var errorContent = await response.Content.ReadAsStringAsync();
        }
    }

   
    public async Task<HttpResponseMessage> Login(string email, string password)
    {
        var loginData = new
        {
            email,
            password
        };

        var content = new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.mateusdata.com.br/login");
        request.Content = content;

        return await _httpClient.SendAsync(request);
    }

   
    public async Task UpdateUser(string userId, string login, string name, string email, string password)
    {
        var userData = new
        {
            login,
            name,
            email,
            password
        };

        var content = new StringContent(JsonSerializer.Serialize(userData), Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Patch, $"https://api.mateusdata.com.br/users/{userId}");
        request.Content = content;
        request.Headers.Add("Authorization", $"Bearer {_token}");

        var response = await _httpClient.SendAsync(request);
    }

   
    public async Task GetUsers()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://api.mateusdata.com.br/users");
        request.Headers.Add("Authorization", $"Bearer {_token}");

        var response = await _httpClient.SendAsync(request);
    }

   
    public async Task GetUserById(string userId)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.mateusdata.com.br/users/{userId}");
        request.Headers.Add("Authorization", $"Bearer {_token}");

        var response = await _httpClient.SendAsync(request);
    }

   
    public async Task DeleteUser(string userId)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"https://api.mateusdata.com.br/users/{userId}");
        request.Headers.Add("Authorization", $"Bearer {_token}");

        var response = await _httpClient.SendAsync(request);
    }

   


    public async Task<HttpResponseMessage> CreateUserWithNullValues()
    {
        var userData = new
        {
            login = "",
            name = "",
            email = "",
            password = ""
        };

        var content = new StringContent(JsonSerializer.Serialize(userData), Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.mateusdata.com.br/users");
        request.Content = content;
        request.Headers.Add("Authorization", $"Bearer {_token}");

        return await _httpClient.SendAsync(request);
    }



    public async Task<HttpResponseMessage> CreateUserWithValidDataAndNullPassword(string login, string name, string email)
    {
        var userData = new
        {
            login,
            name,
            email,
            password = (string)null 
        };

        var content = new StringContent(JsonSerializer.Serialize(userData), Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.mateusdata.com.br/users");
        request.Content = content;
        request.Headers.Add("Authorization", $"Bearer {_token}");

        return await _httpClient.SendAsync(request);
    }


   
    public async Task<HttpResponseMessage> CreatePost(int userId, string message)
    {
        var postData = new
        {
            userId,
            message
        };

        var content = new StringContent(JsonSerializer.Serialize(postData), Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.mateusdata.com.br/posts");
        request.Content = content;
        request.Headers.Add("Authorization", $"Bearer {_token}");

        return await _httpClient.SendAsync(request);
    }



   
    public async Task<HttpResponseMessage> CreatePostWithNullUserIdAndEmptyMessage()
    {
        var postData = new
        {
            userId = (int?)null,
            message = ""       
        };

        var content = new StringContent(JsonSerializer.Serialize(postData), Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.mateusdata.com.br/posts");
        request.Content = content;
        request.Headers.Add("Authorization", $"Bearer {_token}");

        return await _httpClient.SendAsync(request);
    }


   
    public async Task<HttpResponseMessage> CreatePostWithValidUserIdAndEmptyMessage(int userId)
    {
        var postData = new
        {
            userId,
            message = "" 
        };

        var content = new StringContent(JsonSerializer.Serialize(postData), Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.mateusdata.com.br/posts");
        request.Content = content;
        request.Headers.Add("Authorization", $"Bearer {_token}");

        return await _httpClient.SendAsync(request);
    }


   
    public async Task<HttpResponseMessage> UpdatePost(int postId, int userId, string message)
    {
        var postData = new
        {
            userId,
            message
        };

        var content = new StringContent(JsonSerializer.Serialize(postData), Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Patch, $"https://api.mateusdata.com.br/posts/{postId}");
        request.Content = content;
        request.Headers.Add("Authorization", $"Bearer {_token}");

        return await _httpClient.SendAsync(request);
    }


   
    public async Task<HttpResponseMessage> CreateComment(string message, int postId, int userId)
    {
        var commentData = new
        {
            message,
            postId,
            userId
        };

        var content = new StringContent(JsonSerializer.Serialize(commentData), Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.mateusdata.com.br/comments");
        request.Content = content;
        request.Headers.Add("Authorization", $"Bearer {_token}");

        return await _httpClient.SendAsync(request);
    }


}
