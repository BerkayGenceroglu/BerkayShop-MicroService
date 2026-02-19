// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;
using static IdentityServer4.Events.TokenIssuedSuccessEvent;
using static System.Formats.Asn1.AsnWriter;

namespace BerkayShop.IdentityServer
{
    public static class Config
    {
        //API Resource, korunacak bir API'yi temsil eder.
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){ Scopes = {"CatalogFullPermission"}},
            new ApiResource("ResourceMessage"){ Scopes = {"MessageFullPermission"}},
            new ApiResource("ResourceDiscount"){ Scopes = {"DiscountFullPermission"}},
            new ApiResource("ResourceOrder"){ Scopes = {"OrderFullPermission"} },
            new ApiResource("ResourceComment"){ Scopes = {"CommentFullPermission"} },
            new ApiResource("ResourceCargo"){ Scopes = {"CargoFullPermission"} },
            new ApiResource("ResourceBasket"){ Scopes = {"BasketFullPermission"} },
            new ApiResource("ResourceOcelot"){ Scopes = {"OcelotFullPermission"} },
            new ApiResource("ResourcePayment"){ Scopes = {"PaymentFullPermission"} },
            new ApiResource("ResourceImage"){ Scopes = { "ImageFullPermission" } },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
            //"IdentityServer'ın kendi API'sini koru".
            //Bu satır, IdentityServer’ın kendi API’lerini “korunan API” olarak ilan etmek için yazılır.
        };

        //Identity Resource, kullanıcı hakkındaki bilgileri(claim'leri) gruplandırır.Token içine eklenecek kullanıcı bilgilerini (claim) tanımlar.
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };


        //ApiScope, bir kullanıcının veya client'ın ne yapabileceğini belirler.
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            //Message  
            new ApiScope("MessageFullPermission","Full access to Message API"),
            //Catalog
            new ApiScope("CatalogFullPermission","Full access to Catalog API"),

            //Discount
            new ApiScope("DiscountFullPermission","Full access to Discount API"),

            //Order
            new ApiScope("OrderFullPermission","Full access to Order API"),

            //Comment
            new ApiScope("CommentFullPermission","Full access to Comment API"),

            //Cargo
            new ApiScope("CargoFullPermission","Full access to Cargo API"),

            //Basket
            new ApiScope("BasketFullPermission","Full access to Basket API"),

            //Ocelot
            new ApiScope("OcelotFullPermission","Full access to Ocelot API"),

            //Payment
            new ApiScope("PaymentFullPermission","Full access to Payment API"),

            //Image
            new ApiScope("ImageFullPermission","Full access to Image API"),

            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
              // IdentityServer'ın kendi API'sine erişim scope'u
              //Client'ların talep edebileceği izin kapsamlarını tanımlar
              //Client bu scope'u talep ettiğinde, IdentityServer'ın kendi API'sine erişim yetkisi alır
        };

        //Client tanımlarıyla IdentityServer’a şunu söylüyorsun:“Kimler benden token alabilir ve aldıkları token ile ne kadar yetkiye(scope) sahip olabilirler?”.
        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId ="BerkayShopVisitorId",
                ClientName="BerkayShop Visitor User",
                AllowedGrantTypes= GrantTypes.ClientCredentials,/*bir uygulamanın (client) kullanıcı adına değil, kendi adına API'ye erişmek için kullandığı yöntemdir.Sistemde gerçek bir kişi (insan) yoktur; bir yazılımın, başka bir yazılıma kendi kimliğini ispatlayarak bağlanmasıdır.*/
                //ClientCredentials = uygulamanın kullanıcı olmadan, kendi kimliğiyle token alması
                ClientSecrets={ new Secret("BerkayShopVisitorSecret".Sha256()) },
                AllowedScopes={ "DiscountFullPermission", "CatalogFullPermission", "OcelotFullPermission", "CommentFullPermission", "OrderFullPermission", "MessageFullPermission" }
            },

            //Manager
            new Client
            {
                ClientId ="BerkayShopManagerId",/*Bu istemciyi tanımlayan benzersiz kimlik*/
                ClientName="BerkayShop Manager User",/*İnsanların okuyabileceği isim*/
                AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                ClientSecrets={ new Secret("BerkayShopManagerSecret".Sha256()) },/*İstemcinin şifresi (Sha256 ile hashlenmiş)*/
                AllowedScopes = { "CatalogFullPermission","OcelotFullPermission", "PaymentFullPermission",
                    "ImageFullPermission","CommentFullPermission","MessageFullPermission",
                    "CargoFullPermission",
                    "BasketFullPermission","DiscountFullPermission","OrderFullPermission",
                     IdentityServerConstants.LocalApi.ScopeName,// IdentityServer'ın kendi API'sine erişim
                    IdentityServerConstants.StandardScopes.Email,// Email bilgisi
                    IdentityServerConstants.StandardScopes.OpenId,// Kullanıcı kimliği
                    IdentityServerConstants.StandardScopes.Profile, // Kullanıcı profil bilgileri (ad, soyad vb.)
                }/*BU CLIENT NE YAPABİLİR?*/
            },

            //Admin
            new Client
            {
                ClientId ="BerkayShopAdminId",
                ClientName="BerkayShop Admin User",
                AllowedGrantTypes= GrantTypes.ResourceOwnerPassword, /*kullanıcının kullanıcı adı ve şifresini doğrudan uygulamaya vererek token almasını sağlayan bir yetkilendirme yöntemidir.*/
                ClientSecrets={ new Secret("BerkayShopAdminSecret".Sha256()) },
                AllowedScopes =
                {
                    "CommentFullPermission",
                    "BasketFullPermission",
                    "CargoFullPermission",
                    "CatalogFullPermission",
                    "DiscountFullPermission",
                    "OrderFullPermission",
                    "OcelotFullPermission",
                    "PaymentFullPermission",
                    "ImageFullPermission",
                    "MessageFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,// IdentityServer'ın kendi API'sine erişim
                    IdentityServerConstants.StandardScopes.Email,// Email bilgisi
                    IdentityServerConstants.StandardScopes.OpenId,// Kullanıcı kimliği
                    IdentityServerConstants.StandardScopes.Profile, // Kullanıcı profil bilgileri (ad, soyad vb.)
                }
            }
         };
    }
}