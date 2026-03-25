# 🔐 Authentication Token Flow - Visual Guide

## How the JWT Token Travels Through Your Blazor App

```
┌─────────────────────────────────────────────────────────────────┐
│                        1. USER LOGS IN                           │
└─────────────────────────────────────────────────────────────────┘
                              │
                              ▼
            ┌────────────────────────────────┐
            │    Login.razor                 │
            │    User enters credentials     │
            └────────────────────────────────┘
                              │
                              ▼
            ┌────────────────────────────────┐
            │    AuthService.Login()         │
            │    Calls API with credentials  │
            └────────────────────────────────┘
                              │
                              ▼
            ┌────────────────────────────────┐
            │    Backend API                 │
            │    Returns JWT Token           │
            │    "eyJhbGciOiJIUzI1NiIs..."    │
            └────────────────────────────────┘
                              │
                              ▼
            ┌────────────────────────────────┐
            │ CustomAuthStateProvider        │
            │ .NotifyUserAuthentication()    │
            │                                │
            │ ✅ TOKEN STORED HERE!          │
            │ private string? _currentToken  │
            └────────────────────────────────┘


┌─────────────────────────────────────────────────────────────────┐
│              2. USER MAKES API REQUEST (Any Page)                │
└─────────────────────────────────────────────────────────────────┘
                              │
                              ▼
            ┌────────────────────────────────┐
            │    Index.razor.cs              │
            │    Http.GetAsync()             │
            │    (NO token code here!)       │
            └────────────────────────────────┘
                              │
                              ▼
            ┌────────────────────────────────┐
            │  AuthHttpMessageHandler        │
            │  ⚡ INTERCEPTS REQUEST          │
            │  (Before it's sent)            │
            └────────────────────────────────┘
                              │
                              ▼
            ┌────────────────────────────────┐
            │ CustomAuthStateProvider        │
            │ .GetToken()                    │
            │ Returns stored token           │
            └────────────────────────────────┘
                              │
                              ▼
            ┌────────────────────────────────┐
            │  AuthHttpMessageHandler        │
            │  Adds Header:                  │
            │  Authorization: Bearer {token} │
            └────────────────────────────────┘
                              │
                              ▼
            ┌────────────────────────────────┐
            │    Request Sent to API         │
            │    WITH TOKEN ATTACHED! ✅      │
            └────────────────────────────────┘


┌─────────────────────────────────────────────────────────────────┐
│                    KEY CONCEPTS EXPLAINED                        │
└─────────────────────────────────────────────────────────────────┘

## Q: Where is the token stored?
A: In CustomAuthStateProvider._currentToken (in memory)

## Q: How long does it last?
A: Until the user refreshes the page or closes the browser
   (For persistent storage, you'd need to save it to localStorage)

## Q: Do I need to add the token to every request?
A: NO! AuthHttpMessageHandler does it automatically for ALL requests

## Q: How does the token work across different pages?
A: CustomAuthStateProvider is registered as a service, so the same
   instance (with the same token) is used throughout your entire app

## Q: What if the token expires?
A: The backend will return 401 Unauthorized, and you should redirect
   the user back to the login page


┌─────────────────────────────────────────────────────────────────┐
│                    FILE RESPONSIBILITIES                         │
└─────────────────────────────────────────────────────────────────┘

📁 CustomAuthStateProvider.cs
   - Stores the JWT token in memory
   - Provides token to AuthHttpMessageHandler
   - Manages user authentication state

📁 AuthHttpMessageHandler.cs  
   - Intercepts EVERY HTTP request
   - Automatically adds Bearer token to headers
   - This is why you don't see token code in your pages!

📁 Program.cs
   - Wires everything together
   - Registers HttpClient with AuthHttpMessageHandler
   - This setup makes the "magic" happen

📁 Index.razor.cs (or any page)
   - Just calls Http.GetAsync() or Http.PostAsync()
   - Token is added automatically behind the scenes
   - You never touch the token here!


┌─────────────────────────────────────────────────────────────────┐
│                    DESIGN PATTERN NAME                           │
└─────────────────────────────────────────────────────────────────┘

This is called the "Delegating Handler Pattern"

It's a middleware pattern where handlers can:
1. Inspect requests before they're sent
2. Modify the request (add headers)
3. Pass it to the next handler
4. Inspect responses before they return

It's perfect for cross-cutting concerns like:
- Authentication (adding tokens)
- Logging
- Retry logic
- Error handling
