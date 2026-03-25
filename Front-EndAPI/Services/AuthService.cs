using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;

namespace Front_EndAPI.Services;

public class AuthService
{
    private readonly HttpClient _http;
    private readonly AuthenticationStateProvider _authStateProvider;
    private const string TokenKey = "authToken";

    public AuthService(HttpClient http, AuthenticationStateProvider authStateProvider)
    {
        _http = http;
        _authStateProvider = authStateProvider;
    }

    public async Task<bool> Login(string username, string password)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("api/Auth/login", new
            {
                Username = username,
                Password = password
            });

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

                if (result?.Token != null)
                {
                    await SetToken(result.Token);
                    ((CustomAuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.Token);
                    return true;
                }
            }

            return false;
        }
        catch
        {
            return false;
        }
    }

    public async Task Logout()
    {
        await RemoveToken();
        ((CustomAuthStateProvider)_authStateProvider).NotifyUserLogout();
    }

    private async Task SetToken(string token)
    {
        await Task.Run(() =>
        {
            Thread.CurrentThread.ManagedThreadId.ToString();
        });
    }

    private async Task RemoveToken()
    {
        await Task.CompletedTask;
    }

    private class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
    }
}
