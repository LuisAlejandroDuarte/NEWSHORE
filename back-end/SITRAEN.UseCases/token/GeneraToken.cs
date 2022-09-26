
using Microsoft.IdentityModel.Tokens;
using NEWSHORE.DTOs.Login;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



namespace NEWSHORE.UseCases.token
{
    public static class GeneraToken
    {
        public static JwtSecurityToken GeneratorToken(LoginDTO login, JwtSettings jwtSettings)
        {


            //var roleClaims = new List<Claim>();
            //var claims = new[]
            //{
            //    new Claim(JwtRegisteredClaimNames.Sub,login.UserName) ,
            //    new Claim(CustomClaimTypes.Uid,login.UserName.ToString())
            //}.Union(roleClaims);

            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));

            var signingCredetials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(

                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,                
                expires: DateTime.UtcNow.AddMinutes(jwtSettings.DurationInMinutes),
                signingCredentials: signingCredetials
           );

            return jwtSecurityToken;
        }
    }
}
