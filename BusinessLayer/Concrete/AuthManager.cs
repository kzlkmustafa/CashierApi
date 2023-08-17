using BusinessLayer.Abstract;
using BusinessLayer.Constant;
using BusinessLayer.Security.Hashing;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using CoreLayer.Utilities.Security.jwt;
using EntityLayer.Concrete;
using EntityLayer.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        private IAppUserService _userservice;
        private ITokenHelper _tokenhelper;

        public AuthManager(IAppUserService userservice, ITokenHelper tokenhelper)
        {
            _userservice = userservice;
            _tokenhelper = tokenhelper;
        }

        public async Task<IDataResult<AccessToken>> CreateAccessToken(AppUser appuser)
        {
            var claims = await _userservice.GetClaims(appuser);
            var accesstoken = await _tokenhelper.CreateToken(appuser, claims.Data);
            return new DataResult<AccessToken>(accesstoken,true, Messages.Succesfully);

        }

        public async Task<IDataResult<AppUser>> Login(LoginDto logindto)
        {
            var userToCheck = await _userservice.GetByMail(logindto.Email);
            if (userToCheck == null)
            {
                return new DataResult<AppUser>(null, false, Messages.NotFound);

            }
            if (!HashingHelper.VerifyPasswordHash(logindto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {

                return new DataResult<AppUser>(null, false, Messages.Wrong);
            }
            return new DataResult<AppUser>(userToCheck.Data,true,Messages.Succesfully);
        }

        public async Task<IDataResult<AppUser>> Register(RegisterDto registerdto)
        {
            byte[] PasswordHash, PasswordSalt;
            HashingHelper.CreatePasswordHash(registerdto.Password,out PasswordHash,out PasswordSalt);
            var user = new AppUser
            {
                Email = registerdto.Email,
                UserName = registerdto.UserName,
                NameSurname = registerdto.Name + " " + registerdto.Surname,
                Gender = registerdto.Gender,
                Birthdate = registerdto.Birthdate,
                Telnr = registerdto.Telnr,
                PasswordHash = PasswordHash,
                PasswordSalt = PasswordSalt,
                Status = true
            };
            await _userservice.Add(user);
            return new DataResult<AppUser>(user, true, Messages.Succesfully);
        }

        public async Task<IResult> USerExist(string mail)
        {
            if ( await _userservice.GetByMail(mail) == null)
            {
                return new Result(true, Messages.Succesfully);
                
            }
            return new Result(false, Messages.Already);
        }
    }
}
