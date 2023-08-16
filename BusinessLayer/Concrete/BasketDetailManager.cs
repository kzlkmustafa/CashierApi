using BusinessLayer.Abstract;
using BusinessLayer.Constant;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
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

        public BasketDetailManager(IBasketDetailDal basketdetaildal)
        {
            _basketdetaildal = basketdetaildal;
        }

        public async Task<IResult> Add(BasketDetail entity)
        {
            try
            {
                entity.CreateDate =DateTime.Now;
                await _basketdetaildal.AddAsync(entity);
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

        public async Task<IDataResult<BasketDetail>> GetById(int id)
        {
            try
            {
                BasketDetail mybasketdetail = await _basketdetaildal.GetByIdAsync(x => x.BasketDetailId == id);
                return new DataResult<BasketDetail>(mybasketdetail, true,Messages.Succesfully);

            }catch(Exception ex)
            {
                return new DataResult<BasketDetail>(null, false,ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<BasketDetail>>> GetList()
        {
            try
            {
                IEnumerable<BasketDetail> basketDetails = (await _basketdetaildal.GetAllAsync()).ToList();
                return new DataResult<IEnumerable<BasketDetail>>(basketDetails, true, Messages.Succesfully);

            }
            catch(Exception ex)
            {
                return new DataResult<IEnumerable<BasketDetail>>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<BasketDetail>>> GetListbyBasketId(int basketId)
        {
            try
            {
                IEnumerable<BasketDetail> basketDetails = (await _basketdetaildal.GetAllAsync(x => x.BasketId == basketId)).ToList();
                return new DataResult<IEnumerable<BasketDetail>>(basketDetails,true, Messages.Succesfully);

            }
            catch(Exception ex)
            {
                return new DataResult<IEnumerable<BasketDetail>>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<BasketDetail>>> GetListbyProductId(int productId)
        {
            try
            {
                IEnumerable<BasketDetail> basketDetails = (await _basketdetaildal.GetAllAsync(x => x.ProductId == productId)).ToList();
                return new DataResult<IEnumerable<BasketDetail>>(basketDetails, true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new DataResult<IEnumerable<BasketDetail>>(null, false, ex.Message);

            }
        }

        public async Task<IResult> Update(BasketDetail entity)
        {
            try
            {
                await _basketdetaildal.UpdateAsync(entity);
                return new Result(true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);

            }
        }
    }
}
