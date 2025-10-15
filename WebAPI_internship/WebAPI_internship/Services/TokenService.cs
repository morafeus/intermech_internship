using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using WebAPI_internship.Models;

namespace WebAPI_internship.Services
{
    public class TokenService 
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _accessTokenExpireMinutes;

        public TokenService(IConfiguration configuration)
        {
            _key = configuration["Jwt:Key"];
            _issuer = configuration["Jwt:Issuer"];
            _audience = configuration["Jwt:Audience"];
            _accessTokenExpireMinutes = int.Parse(configuration["Jwt:AccessTokenExpireMinutes"]);
        }

        public string GenerateAccessToken(Guid id, string name)
        {
            var claims = new[]
            {
                new Claim("Id", id.ToString()),
                new Claim("UserName", name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_accessTokenExpireMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public static User GetUserFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var authHeader = token.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            var id = tokenS.Claims.First(claim => claim.Type == "Id").Value;

            var user = Store.Users.Where(u => u.Id == new Guid(id)).FirstOrDefault();
            return user;
        }
    }
}
