using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Constant;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        readonly private IAppUserDal _appuserdal;
        readonly private IMapper _mapper;

        public AppUserManager(IAppUserDal appuserdal, IMapper mapper)
        {
            _appuserdal = appuserdal;
            _mapper = mapper;
        }
        public async Task<IResult> Add(AppUser appUser)
        {
            try
            {
                await _appuserdal.AddAsync(appUser);
                return new Result(true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<IResult> Delete(int id)
        {
            try
            {
                await _appuserdal.DeleteAsync(id);
                return new Result(true, Messages.Succesfully);

            } catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
        public async Task<IResult> Update(AppUserDto entity)
        {
            var result = _mapper.Map<AppUser>(entity);
            try
            {
                await _appuserdal.UpdateAsync(result);
                return new Result(true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<IDataResult<AppUserDto>> GetById(int id)
        {
            try
            {
                AppUser entity = await _appuserdal.GetAsync(x => x.AppUserId == id);
                var result = _mapper.Map<AppUserDto>(entity);
                return new DataResult<AppUserDto>(result, true, Messages.Succesfully);
            }
            catch (Exception ex)
            {
                return new DataResult<AppUserDto>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<OperationClaim>>> GetClaims(AppUser user)
        {
            try
            {
                IEnumerable<OperationClaim> entity = (await _appuserdal.GetClaimsAsync(user)).ToList();
                return new DataResult<IEnumerable<OperationClaim>>(entity, true, Messages.Succesfully);
            }
            catch (Exception ex)
            {
                return new DataResult<IEnumerable<OperationClaim>>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<AppUserDto>>> GetList()
        {
            try
            {
                IEnumerable<AppUser> entity = (await _appuserdal.GetAllAsync()).ToList();
                var result = _mapper.Map<IEnumerable<AppUser>, IEnumerable<AppUserDto>>(entity);
                return new DataResult<IEnumerable<AppUserDto>>(result, true, Messages.Succesfully);
            }
            catch (Exception ex)
            {
                return new DataResult<IEnumerable<AppUserDto>>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<AppUser>> GetByMail(string mail)
        {
            try
            {
                AppUser entity = await _appuserdal.GetAsync(x => x.Email == mail);
                var result = _mapper.Map<AppUser>(entity);

                return new DataResult<AppUser>(result, true, Messages.Succesfully);
            }
            catch (Exception ex)
            {
                return new DataResult<AppUser>(null, false, ex.Message);

            }
        }
    }
}
