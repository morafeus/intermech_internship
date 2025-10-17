using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI_internship.Models;

namespace WebAPI_internship.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateAccessToken(Guid id, string name);
        public User GetUserFromToken(string token);
    }
}
