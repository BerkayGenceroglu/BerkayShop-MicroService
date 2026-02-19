using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.PortableExecutable;
using System.Security.Claims;
using System.Text;

namespace BerkayShop.IdentityServer.Tools

{
	public class JwtTokenGenerator
	{
		public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
		{
			var claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(model.Role))
				claims.Add(new Claim(ClaimTypes.Role, model.Role));

			claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id));

            if (!string.IsNullOrWhiteSpace(model.Username))
			 claims.Add(new Claim("Username", model.Username));

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.key));
			var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);
			JwtSecurityToken token = new JwtSecurityToken(
				issuer: JwtTokenDefaults.ValidIssuer,
				audience: JwtTokenDefaults.ValidAudience,
				claims: claims,
				notBefore: DateTime.UtcNow,
				expires: expireDate,
				signingCredentials: signingCredentials
				);
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			return new TokenResponseViewModel(tokenHandler.WriteToken(token), expireDate);
			//JwtSecurityToken nesnesini
			//Header.Payload.Signature formatında string JWT’ye çevirir

		}
	}
}
