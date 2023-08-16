using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Constant;
using CoreLayer.Entities;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BasketDetailManager : IBasketDetailService
    {
        readonly private IBasketDetailDal _basketdetaildal;
        readonly private IMapper _mapper;

        public BasketDetailManager(IBasketDetailDal basketdetaildal, IMapper mapper)
        {
            _basketdetaildal = basketdetaildal;
            _mapper = mapper;
        }

        public async Task<IResult> Add(BasketDetailAddDto entity)
        {
            var result = _mapper.Map<BasketDetail>(entity);
            try
            {
                result.CreateDate =DateTime.Now;
                await _basketdetaildal.AddAsync(result);
                return new Result(true, Messages.Succesfully);

            }catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<IResult> Delete(int id)
        {
            try
            {
                await _basketdetaildal.DeleteAsync(id);
                return new Result(true, Messages.Succesfully);

            }catch(Exception ex)
            {
                return new Result(false, ex.Message);

            }
        }
        public async Task<IResult> Update(BasketDetailDto entity)
        {
            var result = _mapper.Map<BasketDetail>(entity);
            try
            {
                await _basketdetaildal.UpdateAsync(result);
                return new Result(true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);

            }
        }

        public async Task<IDataResult<BasketDetailDto>> GetById(int id)
        {
            try
            {
                BasketDetail entity = await _basketdetaildal.GetByIdAsync(x => x.BasketDetailId == id);
                var result = _mapper.Map<BasketDetailDto>(entity);

                return new DataResult<BasketDetailDto>(result, true,Messages.Succesfully);

            }catch(Exception ex)
            {
                return new DataResult<BasketDetailDto>(null, false,ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<BasketDetailDto>>> GetList()
        {
            try
            {
                IEnumerable<BasketDetail> entities = (await _basketdetaildal.GetAllAsync()).ToList();
                var result = _mapper.Map<IEnumerable<BasketDetail>, IEnumerable<BasketDetailDto>>(entities);

                return new DataResult<IEnumerable<BasketDetailDto>>(result, true, Messages.Succesfully);

            }
            catch(Exception ex)
            {
                return new DataResult<IEnumerable<BasketDetailDto>>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<BasketDetailDto>>> GetListbyBasketId(int basketId)
        {
            try
            {
                IEnumerable<BasketDetail> entities = (await _basketdetaildal.GetAllAsync(x => x.BasketId == basketId)).ToList();
                var result = _mapper.Map<IEnumerable<BasketDetail>, IEnumerable<BasketDetailDto>>(entities);

                return new DataResult<IEnumerable<BasketDetailDto>>(result, true, Messages.Succesfully);

            }
            catch(Exception ex)
            {
                return new DataResult<IEnumerable<BasketDetailDto>>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<BasketDetailDto>>> GetListbyProductId(int productId)
        {
            try
            {
                IEnumerable<BasketDetail> entities = (await _basketdetaildal.GetAllAsync(x => x.ProductId == productId)).ToList();
                var result = _mapper.Map<IEnumerable<BasketDetail>, IEnumerable<BasketDetailDto>>(entities);

                return new DataResult<IEnumerable<BasketDetailDto>>(result, true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new DataResult<IEnumerable<BasketDetailDto>>(null, false, ex.Message);

            }
        }

        
    }
}
