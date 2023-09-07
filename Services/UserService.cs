
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
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

    public async Task PostUser(UserViewModel user)
    {
        using HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
            _location,
            user
        );
    }

    public async Task<HttpResponseMessage> Login(UserViewModel user) {
        var res = await _httpClient.GetAsync(_location + $"{user.Name}/{user.Pwd}");
        return res;
    }
}