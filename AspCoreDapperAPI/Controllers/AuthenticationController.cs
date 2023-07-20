using AspCoreDapperAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspCoreDapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }
            if (user.UserName == "pngrbapi" && user.Password == "pngrb@123")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
                var signinCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                //var header = new JwtHeader(signinCredentials);
                //DateTime Expiry = DateTime.UtcNow.AddMinutes(1);
                //int ts = (int)(Expiry - new DateTime(1970,1,1)).TotalSeconds;
                //var payload = new JwtPayload
                //{
                //    {"sub","testSubject" },
                //    { "Name","Biswajit" },
                //    {"email","biswajit.das@cyberswift.com" },
                //    { "exp",ts },
                //    {"iss",ConfigurationManager.AppSetting["JWT:ValidIssuer"] },
                //    {"aud",ConfigurationManager.AppSetting["JWT:ValidAudience"] }
                //};
                //var secToken=new JwtSecurityToken(header, payload);
                //var handler = new JwtSecurityTokenHandler();
                //var tokenString= handler.WriteToken(secToken);

                var tokeOptions = new JwtSecurityToken(
                    issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"],
                    audience: ConfigurationManager.AppSetting["JWT:ValidAudience"],
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new JWTTokenResponse { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}
