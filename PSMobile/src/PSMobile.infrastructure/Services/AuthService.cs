using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using PSMobile.core.Entities;
using PSMobile.core.Interfaces;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

using ZXing.Aztec.Internal;

using static MudBlazor.Colors;

namespace PSMobile.infrastructure.Services;
public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string ComputeSha256Hash(string password)
    {
        //Inicializando o método do sha256 Create
        using (SHA256 sha256Hash = SHA256.Create())
        {
            //ComputeHash - retorna byte array
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            //Converte byte array para string
            StringBuilder builder = new StringBuilder();//concatenação de string

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));// 2x faz com que sseja convertido em representação hexadecimal
            }
            return builder.ToString();
        }

    }
    public string GenerateJwtToken(Usuarios userBD)
    {
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var key = _configuration["Jwt:Key"];

        var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

        var subject = new List<Claim>(
            new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userBD.usu_emp_key.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, userBD.usu_nome)
            });

        var expires = DateTime.UtcNow.AddMinutes(60);

        var token = new JwtSecurityToken
        (
            issuer: issuer,
            audience: audience,
            claims: subject,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
        );


        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);


        return tokenString.ToString();
    }
}
