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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BasketManager : IBasketService
    {
        readonly private IBasketDal _basketdal;
        readonly private IMapper _mapper;

        public BasketManager(IBasketDal basketdal, IMapper mapper)
        {
            _basketdal = basketdal;
            _mapper = mapper;
        }

        public async Task<IResult> Add(BasketAddDto entity)
        {
            var result = _mapper.Map<Basket>(entity);
            try
            {
                result.CreatedDate = DateTime.Now;
                await _basketdal.AddAsync(result);
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
                await _basketdal.DeleteAsync(id);
                return new Result(true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);

            }
        }
        public async Task<IResult> Update(BasketDto entity)
        {
            var result = _mapper.Map<Basket>(entity);
            try
            {
                await _basketdal.UpdateAsync(result);
                return new Result(true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);

            }
        }

        public async Task<IDataResult<BasketDto>> GetById(int id)
        {
            try
            {
                Basket basket = await _basketdal.GetAsync(x => x.BasketId == id);
                var result = _mapper.Map<BasketDto>(basket);

                return new DataResult<BasketDto>(result, true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new DataResult<BasketDto>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<BasketDto>>> GetList()
        {
            try
            {
                IEnumerable<Basket> entities = (await _basketdal.GetAllAsync()).ToList();
                var result = _mapper.Map<IEnumerable<Basket>, IEnumerable<BasketDto>>(entities);

                return new DataResult<IEnumerable<BasketDto>>(result, true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new DataResult<IEnumerable<BasketDto>>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<BasketDto>>> GetListByCashier(int appuserid)
        {
            try
            {
                IEnumerable<Basket> entities = (await _basketdal.GetAllAsync(x => x.AppUserId == appuserid)).ToList();
                var result = _mapper.Map<IEnumerable<Basket>, IEnumerable<BasketDto>>(entities);

                return new DataResult<IEnumerable<BasketDto>>(result, true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new DataResult<IEnumerable<BasketDto>>(null, false, ex.Message);

            }
        }

        
    }
}
