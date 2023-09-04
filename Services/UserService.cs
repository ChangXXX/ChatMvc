
using ChatMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatMvc.Services;

public class UserService
{
    private readonly HttpClient _httpClient;
    private static string _location = "Users/";

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

    public async Task<HttpResponseMessage> Login(User user) {
        var res = await _httpClient.GetAsync(_location + $"{user.Name}/{user.Pwd}");
        var accessToken = res.Headers.GetValues("Jwt").FirstOrDefault();
        Console.WriteLine($"Token ::: {accessToken}");
        _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
        return res;
    }
}