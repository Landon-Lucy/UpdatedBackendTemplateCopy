using Back_EndAPI.Data;
using Back_EndAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using ClassLibrary.Authorization;

namespace Back_EndAPI.Services;

public class AuthService
{
    private readonly string _key = "THIS_IS_MY_SECRET_KEY_1234567890";
    private readonly AppDbContext _context;

    // In-memory mock users for demo/testing
    private class MockUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string[] Permissions { get; set; }
    }

    private readonly List<MockUser> _mockUsers = new()
    {
        new MockUser { Username = "alice", Password = "password1", Permissions = new[] { Permissions.CharacterCreate, Permissions.CharacterRead, Permissions.UsersRead } },
        new MockUser { Username = "bob", Password = "password2", Permissions = new[] { Permissions.CharacterRead } }
    };

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    // =========================================
    // SIMPLE VERSION (TEACHING / DEMO ONLY)
    // =========================================
    public string? Login(string username, string password)
    {
        return LoginSimple(username, password);
    }

    public string? LoginSimple(string username, string password)
    {
        // Validate against in-memory mock users
        var user = _mockUsers.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user == null)
            return null;

        return GenerateTokenSimple(user);
    }

    private string GenerateTokenSimple(MockUser user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username)
        };

        // Add one claim per permission (permission names are strings like "users.create")
        foreach (var p in user.Permissions)
        {
            claims.Add(new Claim("permission", p));
        }

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }


    // =========================================
    // REAL VERSION (DB + ROLES + PERMISSIONS)
    // =========================================
    public async Task<string?> LoginAsync(string username, string password)
    {
        var user = await _context.Employees
            .FirstOrDefaultAsync(u => u.Name == username);

        if (user == null)
            return null;

        // Replace with hashed password later
        if (password != "password")
            return null;

        return await GenerateTokenAsync(user);
    }

    private async Task<string> GenerateTokenAsync(Employee user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var employeeRoles = await _context.EmployeeRoles
            .Where(er => er.EmployeeId == user.Id && er.RevokedDate == null)
            .Include(er => er.Role)
                .ThenInclude(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
            .ToListAsync();

        var roles = employeeRoles.Select(er => er.Role).ToList();

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        // Roles
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Name));
        }

        // Permissions
        var permissions = roles
            .SelectMany(r => r.RolePermissions)
            .Select(rp => rp.Permission.PermissionName)
            .Distinct();

        foreach (var permission in permissions)
        {
            claims.Add(new Claim("permission", permission));
        }

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}