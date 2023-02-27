using IdentityModel;
using IdentityServer4.Models;

namespace IdentityServer;

public static class Configuration
{
    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
    }

    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new List<ApiResource>
        {
            new("bookingAPI")
        };
    }

    public static IEnumerable<Client> GetClients()
    {
        return new List<Client>
        {
            new()
            {
                ClientId = "client_id",
                ClientSecrets = { new Secret("client_secret".ToSha256()) },

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "bookingAPI" }
            }
        };
    }

    public static IEnumerable<ApiScope> GetApiScopes()
    {
        return new ApiScope[]
        {
            new("bookingAPI")
        };
    }
}