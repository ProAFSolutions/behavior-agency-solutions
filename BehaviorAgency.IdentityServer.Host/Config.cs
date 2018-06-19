// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using BehaviorAgency.Infrastructure;
using BehaviorAgency.Infrastructure.Security;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace BehaviorAgency.IdentityServer.Host
{
    public class Config
    {
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource {
                    Name = CustomResourceScopes.AgencyProfile,
                    DisplayName = "Agency Profile",
                    Required = false,
                    UserClaims = {
                        JwtClaimTypes.Role,
                        CustomClaimTypes.AgencyCode
                    },
                    ShowInDiscoveryDocument = true,
                    Enabled = true
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource {
                    Name = CustomResourceScopes.AgencyApi,
                    DisplayName = "BA API",

                    // secret for using introspection endpoint
                    ApiSecrets = {
                        new Secret(CryptoManager.EncryptSHA256("B@gencyApi4Ever"))
                    },

                     // include the following using claims in access token (in addition to subject id)
                    UserClaims = {
                        JwtClaimTypes.Role,
                        CustomClaimTypes.AgencyCode
                    },
                    Enabled = true,
                }
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                // OpenID Connect hybrid flow and client credentials client (MVC)
                new Client
                {
                    ClientId = "ba_web",
                    ClientName = "BA Web Platform",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    RequireConsent = true,

                    ClientSecrets = 
                    {
                        new Secret(CryptoManager.EncryptSHA256("B@gencyWeb4Ever"))
                    },

                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        CustomResourceScopes.AgencyProfile,
                        CustomResourceScopes.AgencyApi
                    },
                    AllowOfflineAccess = true
                }
            };
        }
    }
}