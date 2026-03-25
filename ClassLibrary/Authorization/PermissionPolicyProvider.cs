using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace ClassLibrary.Authorization
{
    public class PermissionPolicyProvider : DefaultAuthorizationPolicyProvider
    {
        public PermissionPolicyProvider(IOptions<AuthorizationOptions> options)
            : base(options) { }

        public override Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            var policy = new AuthorizationPolicyBuilder()
                .RequireClaim("permission", policyName)
                .Build();

            return Task.FromResult(policy);
        }
    }
}
