using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using CSTokenBaseAuth.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace WebApplicationBasic.Controllers
{
    public class TokenAuthController : Controller
    {
        public string GetAuthToken([FromBody]User user) 
        { 
            var existUser = UserStorage.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password); 
        
            if (existUser != null) 
            { 
                var requestAt = DateTime.Now; 
                var expiresIn = requestAt + TokenAuthOption.ExpiresSpan; 
                var token = GenerateToken(existUser, expiresIn); 
        
                return JsonConvert.SerializeObject(new RequestResult 
                { 
                    State = RequestState.Success, 
                    Data = new 
                    { 
                        requertAt = requestAt, 
                        expiresIn = TokenAuthOption.ExpiresSpan.TotalSeconds, 
                        tokeyType = TokenAuthOption.TokenType, 
                        accessToken = token 
                    } 
                }); 
            } 
            else 
            { 
                return JsonConvert.SerializeObject(new RequestResult 
                { 
                    State = RequestState.Failed, 
                    Msg = "Username or password is invalid" 
                }); 
            } 
        } 
        
        private string GenerateToken(User user, DateTime expires) 
        { 
            var handler = new JwtSecurityTokenHandler(); 
        
            ClaimsIdentity identity = new ClaimsIdentity( 
                new GenericIdentity(user.Username, "TokenAuth"), 
                new[] { 
                    new Claim("ID", user.ID.ToString()) 
                } 
            ); 
        
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor 
            { 
                Issuer = TokenAuthOption.Issuer, 
                Audience = TokenAuthOption.Audience, 
                SigningCredentials = TokenAuthOption.SigningCredentials, 
                Subject = identity, 
                Expires = expires 
            }); 
            return handler.WriteToken(securityToken); 
        }
    }
}