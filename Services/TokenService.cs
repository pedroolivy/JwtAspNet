using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JwtAspNet.Services;

public class TokenService
{
    public string CreateToken()
    {
        // Instancia o manipulador responsável por criar e serializar o token JWT
        var handler = new JwtSecurityTokenHandler();
        
        // Converte a chave "secreta" (string) em um array de bytes
        var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey);
        
        // Cria as credenciais de assinatura com a chave simétrica e o algoritmo HMAC-SHA256
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key), 
            SecurityAlgorithms.HmacSha256);

        //Aquio vai conter as informações que ira ter dentro do nosso token
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(2)
        };
        
        //Aqui nosso token é realmente criado !!!
        var token = handler.CreateToken(tokenDescriptor);
        
        return handler.WriteToken(token);
    }
}