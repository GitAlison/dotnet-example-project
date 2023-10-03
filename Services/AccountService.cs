using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace appflow.Services
{
    public class AccountService : IAccountService
    {
        public IConfiguration _config { get; set; }

        public AccountService(IConfiguration configuration)
        {
            _config = configuration;
        }
        public object GenerateToken(ApplicationUser user)
        {

            string secreteJWT = _config.GetValue<string>("Jwt:Key");
            string Issuer = _config.GetValue<string>("Jwt:Issuer");
            string Audience = _config.GetValue<string>("Jwt:Audience");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secreteJWT));
            var tokenHandler = new JwtSecurityTokenHandler();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new ClaimsIdentity(new[]{
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
                });
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.Now.AddHours(4),
                NotBefore = DateTime.Now,
                SigningCredentials = credentials,


            };

            if (secreteJWT == null)
            {
                throw new NotImplementedException();
            }
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string stringToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new
            {
                accessToken = stringToken
            };
        }
    }
}

