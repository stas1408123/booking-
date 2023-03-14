using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace IdentityServer;

public static class Configuration
{
    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };
    }

    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>
        {
            new("BookingAPI"),
            new("Blazor")
        };
    }

    public static IEnumerable<Client> GetClients()
    {
        return new List<Client>
        {
            new()
            {
                ClientId = "client_id_booking",
                ClientSecrets = { new Secret("client_secret_booking".ToSha256()) },
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowedCorsOrigins = { "https://localhost:10001" },
                AllowedScopes =
                {
                    "BookingAPI",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            },
            new()
            {
                ClientId = "client_id",
                ClientSecrets = { new Secret("client_secret".ToSha256()) },

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes =
                {
                    "BookingAPI"
                },
            },
            new()
            {
                ClientId = "client_id_blazor",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                RequireConsent = false,
                RequirePkce = true,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Address
                },
                RedirectUris = { "https://localhost:9001/authentication/login-callback" },
                PostLogoutRedirectUris = { "https://localhost:9001/authentication/logout-callback" },
                AllowedCorsOrigins = { "https://localhost:9001" }
            }
        };
    }

    public static IEnumerable<ApiScope> GetApiScopes()
    {
        return new ApiScope[]
        {
            new("BookingAPI"),
            new("Blazor")
        };
    }
}