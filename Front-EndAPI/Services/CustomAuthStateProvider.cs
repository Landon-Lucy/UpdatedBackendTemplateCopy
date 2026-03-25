using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Front_EndAPI.Services;

// ============================================================
// CUSTOM AUTH STATE PROVIDER
// ============================================================
public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _anonymous = new(new ClaimsIdentity());
    private string? _currentToken;
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        if (string.IsNullOrEmpty(_currentToken))
        {
            return Task.FromResult(new AuthenticationState(_anonymous));
        }

        var identity = new ClaimsIdentity(ParseClaimsFromJwt(_currentToken), "jwt");
        var user = new ClaimsPrincipal(identity);

        return Task.FromResult(new AuthenticationState(user));
    }

    // ============================================================
    // CALLED WHEN USER LOGS IN
    // ============================================================
    public void NotifyUserAuthentication(string token)
    {
        _currentToken = token;
        var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
        var user = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    // ============================================================
    // CALLED WHEN USER LOGS OUT
    // ============================================================
    public void NotifyUserLogout()
    {
        _currentToken = null;
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
    }

    // ============================================================
    // EXTRACT USER INFO FROM JWT TOKEN
    // ============================================================
    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwt);
        return token.Claims;
    }

    // ============================================================
    // PROVIDE TOKEN TO AuthHttpMessageHandler
    // ============================================================
    public string? GetToken() => _currentToken;
}
