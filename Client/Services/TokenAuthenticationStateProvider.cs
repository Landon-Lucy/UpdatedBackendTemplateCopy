using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Client.Services
{
    public class TokenAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _js;
        private readonly ApiAuthService _apiAuth;
        private ClaimsPrincipal _anonymous = new(new ClaimsIdentity());
        private string? _currentToken;

        public TokenAuthenticationStateProvider(IJSRuntime js, ApiAuthService apiAuth)
        {
            _js = js;
            _apiAuth = apiAuth;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (string.IsNullOrEmpty(_currentToken))
            {
                // Try to initialize from ApiAuthService/localStorage
                await InitializeAsync();
            }

            if (string.IsNullOrEmpty(_currentToken))
                return new AuthenticationState(_anonymous);

            var identity = new ClaimsIdentity(ParseClaimsFromJwt(_currentToken), "jwt");
            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }

        // Call this at app startup to restore token from storage
        public async Task InitializeAsync()
        {
            await _apiAuth.InitializeAsync();
            _currentToken = _apiAuth.GetToken();
            if (!string.IsNullOrEmpty(_currentToken))
            {
                var identity = new ClaimsIdentity(ParseClaimsFromJwt(_currentToken), "jwt");
                var user = new ClaimsPrincipal(identity);
                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
            }
        }

        // Called when user logs in
        public void NotifyUserAuthentication(string token)
        {
            _currentToken = token;
            var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        // Called when user logs out
        public void NotifyUserLogout()
        {
            _currentToken = null;
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
        }

        // Convenience method to check a permission from the current principal
        public bool HasPermission(string permission)
        {
            if (string.IsNullOrEmpty(_currentToken))
                return false;

            var claims = ParseClaimsFromJwt(_currentToken);
            return claims.Any(c => c.Type == "permission" && c.Value == permission);
        }

        // Helper: parse claims from a JWT without validating signature (client-side only)
        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            return token.Claims;
        }

        // Provide token to other services if needed
        public string? GetToken() => _currentToken;
    }
}
