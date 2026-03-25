using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;

namespace Front_EndAPI.Services;

// ============================================================
// AUTH HTTP MESSAGE HANDLER
// ============================================================
public class AuthHttpMessageHandler : DelegatingHandler
{
    private readonly AuthenticationStateProvider _authStateProvider;

    public AuthHttpMessageHandler(AuthenticationStateProvider authStateProvider)
    {
        _authStateProvider = authStateProvider;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (_authStateProvider is CustomAuthStateProvider customProvider)
        {
            var token = customProvider.GetToken();

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
