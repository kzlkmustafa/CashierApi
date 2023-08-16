using BusinessLayer.Abstract;
using BusinessLayer.Constant;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
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

        public BasketManager(IBasketDal basketdal)
        {
            _basketdal = basketdal;
        }

        public async Task<IResult> Add(Basket entity)
        {
            try
            {
                entity.CreatedDate = DateTime.Now;
                await _basketdal.AddAsync(entity);
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

        public async Task<IDataResult<Basket>> GetById(int id)
        {
            try
            {
                Basket basket = await _basketdal.GetByIdAsync(x => x.BasketId == id);
                return new DataResult<Basket>(basket, true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new DataResult<Basket>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<Basket>>> GetList()
        {
            try
            {
                IEnumerable<Basket> baskets = (await _basketdal.GetAllAsync()).ToList();
                return new DataResult<IEnumerable<Basket>>(baskets, true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new DataResult<IEnumerable<Basket>>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<Basket>>> GetListByCashier(int appuserid)
        {
            try
            {
                IEnumerable<Basket> baskets = (await _basketdal.GetAllAsync(x => x.AppUserId == appuserid)).ToList();
                return new DataResult<IEnumerable<Basket>>(baskets, true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new DataResult<IEnumerable<Basket>>(null, false, ex.Message);

            }
        }

        public async Task<IResult> Update(Basket entity)
        {
            try
            {
                await _basketdal.UpdateAsync(entity);
                return new Result(true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);

            }
        }
    }
}
