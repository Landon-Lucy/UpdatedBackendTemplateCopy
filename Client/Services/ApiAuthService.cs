using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using ClassLibrary.DTOs.Auth;

namespace Client.Services
{
    public class ApiAuthService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _js;
        private string? _token;
        private const string TokenKey = "authToken";

        public ApiAuthService(HttpClient http, IJSRuntime js)
        {
            _http = http;
            _js = js;
        }

        // Calls POST api/auth/login, stores returned token in localStorage and sets Authorization header
        public async Task<string?> Login(LoginRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", request);
            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadFromJsonAsync<TokenResponse>();
            if (content == null || string.IsNullOrEmpty(content.Token))
                return null;

            _token = content.Token;
            await _js.InvokeVoidAsync("localStorage.setItem", TokenKey, _token);
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            return _token;
        }

        // Removes token from storage and clears Authorization header
        public async Task Logout()
        {
            _token = null;
            await _js.InvokeVoidAsync("localStorage.removeItem", TokenKey);
            _http.DefaultRequestHeaders.Authorization = null;
        }

        // Returns cached token (set after Login or InitializeAsync)
        public string? GetToken() => _token;

        // Call this at app startup to restore token from localStorage if present
        public async Task InitializeAsync()
        {
            var t = await _js.InvokeAsync<string>("localStorage.getItem", TokenKey);
            if (!string.IsNullOrEmpty(t))
            {
                _token = t;
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            }
        }

        private class TokenResponse
        {
            [JsonPropertyName("token")]
            public string Token { get; set; }
        }
    }
}
