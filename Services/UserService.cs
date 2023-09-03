
using ChatMvc.Models;

namespace ChatMvc.Services;

public class UserService
{
    private readonly HttpClient _httpClient;
    private static string _location = "Users";

    public UserService(
        HttpClient httpClient
    )
    {
        _httpClient = httpClient;
    }

    public async Task PostUser(User user)
    {
        using HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
            _location,
            user
        );
    }
}