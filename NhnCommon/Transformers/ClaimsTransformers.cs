using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using NhnCommon.Shared.Configuration;

namespace NhnCommon.Transformers;

public class ClaimsTransformers : IClaimsTransformation
#pragma warning restore CS1591
{
    private readonly AppSettings _settings;

    public ClaimsTransformers(IOptions<AppSettings> options)
    {
        _settings = options.Value;
    }
    
    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var authorizations = await UserAuthorizations(principal);
        authorizations = authorizations.Concat(ResourceAccessAuthorizations(principal)).ToList();
        authorizations = authorizations.Distinct().ToList();

        var claimsIdentity = new ClaimsIdentity();
        foreach (var authorization in authorizations)
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, authorization));

        principal.AddIdentity(claimsIdentity);

        return await Task.FromResult(principal);
    }
    
    private Task<IEnumerable<string>> UserAuthorizations(ClaimsPrincipal principal)
    {
        var sub = principal.Claims.FirstOrDefault(c => c.Type == _settings.PrincipalSettings.IdClaimType)?.Value;
        if (sub is null)
            return Task.FromResult<IEnumerable<string>>(new List<string>());
        
        return Task.FromResult(Enumerable.Empty<string>());
    }
    
    private IEnumerable<string> ResourceAccessAuthorizations(ClaimsPrincipal principal)
    {
        var emptyAuthorizations = new List<string>();

        try
        {
            var jsonString = principal.Claims.FirstOrDefault(c => c.Type == _settings.PrincipalSettings.ResourceAccessClaimType)
                ?.Value;
            if (string.IsNullOrEmpty(jsonString)) return emptyAuthorizations;

            var resources = JObject.Parse(jsonString);
            var backendResources = resources[_settings.PrincipalSettings.ResourceAccessContext];
            if (backendResources is null) return emptyAuthorizations;

            var roles = backendResources[_settings.PrincipalSettings.ResourceAccessContextRoles]
                .ToObject<string[]>();

            return roles is null
                ? emptyAuthorizations
                : roles;
        }
        catch
        {
            return emptyAuthorizations;
        }
    }
}