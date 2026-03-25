using Front_EndAPI;
using Front_EndAPI.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// ============================================================
// AUTHENTICATION SERVICES REGISTRATION
// ============================================================
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
    provider.GetRequiredService<CustomAuthStateProvider>());
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AuthHttpMessageHandler>();

// ============================================================
// HTTP CLIENT CONFIGURATION 
// ============================================================
builder.Services.AddScoped(sp =>
{
    var handler = sp.GetRequiredService<AuthHttpMessageHandler>();
    handler.InnerHandler = new HttpClientHandler();
    return new HttpClient(handler)
    {
        BaseAddress = new Uri("https://localhost:7147/")
    };
});

// ============================================================
// AUTHORIZATION POLICIES
// ============================================================
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("Create", policy =>
        policy.RequireClaim("permission", "users.create"));
});

await builder.Build().RunAsync();

// ============================================================
// SUMMARY: How Auth Token Flows Through Your App
// ============================================================
