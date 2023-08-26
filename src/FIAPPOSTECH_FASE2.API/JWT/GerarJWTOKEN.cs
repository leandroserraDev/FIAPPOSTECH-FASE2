using FIAPPOSTECH_FASE2.API.Config;
using FIAPPOSTECH_FASE2.DOMAIN.Entities;
using FIAPPOSTECH_FASE2.DTO.Dtos.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FIAPPOSTECH_FASE2.API.JWT
{
    public static class GerarJWTOKEN
    {



        public static async Task<string> GerarToken(UsuarioDTO usuarioLogin, IConfiguration _configuration)
        {
            var appSettings = _configuration.GetSection("AppSetting").Get<AppSettings>();


            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sid, usuarioLogin.id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Name, usuarioLogin.nome));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, usuarioLogin.email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.Now).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.Now).ToString()));

            var identityClaims = new ClaimsIdentity();

            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Segredo);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = appSettings.Emissor,
                Audience = appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);


            return await Task.FromResult(encodedToken);
        }

        private static long ToUnixEpochDate(DateTime date) => new DateTimeOffset(date).ToUniversalTime().ToUnixTimeSeconds();



    }
}
