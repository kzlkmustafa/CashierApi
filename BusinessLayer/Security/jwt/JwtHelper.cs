using BusinessLayer.Security.Encyption;
using CoreLayer.Extensions;
using CoreLayer.Utilities.Security.jwt;
using EntityLayer.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Security.jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration);
        }
        public async Task<AccessToken> CreateToken(AppUser appuser, IEnumerable<OperationClaim> operationclaims)
        {
            var securitykey = await SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey);
            var signincredential = await SigningCredentialsHelper.CreateSigninCreadenitals(securitykey);
            var jwt = await CreateJwtSecurityToken(tokenOptions, appuser, signincredential, operationclaims);
            var jwtsecuritytokenhandler = new JwtSecurityTokenHandler();
            var token = jwtsecuritytokenhandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };


        }
        public async Task<JwtSecurityToken> CreateJwtSecurityToken(TokenOptions tokenOptions, AppUser appUser, SigningCredentials signingCredentials , IEnumerable<OperationClaim> operationClaims)
        {

            await Task.Delay(10);
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(appUser,operationClaims),
                signingCredentials: signingCredentials
                );
            return jwt;

        }
        private IEnumerable<Claim> SetClaims(AppUser appUser, IEnumerable<OperationClaim> operationclaims)
        {
            var claims = new List<Claim>();
            claims.AddEmail(appUser.Email);
            claims.AddName(appUser.NameSurname);
            claims.AddNameIdentifier(appUser.AppUserId.ToString());
            claims.AddRole(operationclaims.Select(x => x.Name).ToArray());
            return claims;
        }
    }
}
