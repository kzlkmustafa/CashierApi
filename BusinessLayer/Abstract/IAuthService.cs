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

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        //register, login, userexist,CreateAccessToken
        Task<IDataResult<AppUser>> Register(RegisterDto registerdto);
        Task<IDataResult<AppUser>> Login(LoginDto logindto);
        Task<IResult> USerExist(string mail);
        Task<IDataResult<AccessToken>> CreateAccessToken(AppUser appuser);
    }
}
