namespace NhnCommon.Shared.Configuration;

public class AppSettings
{
    public TokenParameters TokenParameters { get; set; } = new();
    public PrincipalSettings PrincipalSettings { get; set; } = new();
}

public class TokenParameters
{
    public string ServerRealm { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public string Metadata { get; set; } = string.Empty;
}

public class PrincipalSettings
{
    public string IdClaimType { get; set; } = string.Empty;
    public string ResourceAccessClaimType { get; set; } = string.Empty;
    public string ResourceAccessContext { get; set; } = string.Empty;
    public string ResourceAccessContextRoles { get; set; } = string.Empty;
}