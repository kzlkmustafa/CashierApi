using BusinessLayer.Abstract;
using BusinessLayer.Constant;
using CoreLayer.Entities;
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
    public class ProductManager : IProductService
    {
        readonly private IProductDal _productdal;

        public ProductManager(IProductDal productdal)
        {
            _productdal = productdal;
        }

        public async Task<IResult> Add(Product entity)
        {
            try
            {
                await _productdal.AddAsync(entity);
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
                await _productdal.DeleteAsync(id);
                return new Result(true, Messages.Succesfully);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public async Task<IDataResult<Product>> GetById(int id)
        {
            try
            {
                Product myEntity = await _productdal.GetByIdAsync(x => x.ProductId == id);
                return new DataResult<Product>(myEntity, true, Messages.Succesfully);
                new DataResult<Product>(data: myEntity, message:Messages.Succesfully, success: true);
            }
            catch (Exception ex)
            {
                return new DataResult<Product>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<Product>>> GetList()
        {
            try
            {
                IEnumerable<Product> myEntity = (await _productdal.GetAllAsync()).ToList();
                return new DataResult<IEnumerable<Product>>(myEntity, true, Messages.Succesfully);
            }
            catch (Exception ex)
            {
                return new DataResult<IEnumerable<Product>>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<Product>>> GetListByCategoryId(int categoryId)
        {
            try
            {
                IEnumerable<Product> myEntity = (await _productdal.GetAllAsync(x => x.CategoryId == categoryId)).ToList();
                return new DataResult<IEnumerable<Product>>(myEntity, true, Messages.Succesfully);
            }
            catch (Exception ex)
            {
                return new DataResult<IEnumerable<Product>>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<Product>>> GetListByKdvId(int kdvId)
        {
            try
            {
                IEnumerable<Product> myEntity = (await _productdal.GetAllAsync(x => x.CategoryId == kdvId)).ToList();
                return new DataResult<IEnumerable<Product>>(myEntity, true, Messages.Succesfully);
            }
            catch (Exception ex)
            {
                return new DataResult<IEnumerable<Product>>(null, false, ex.Message);

            }
        }

        public async Task<IResult> Update(Product entity)
        {
            try
            {
                await _productdal.UpdateAsync(entity);
                return new Result(true,Messages.Succesfully); 

            }catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }

        }
    }
}
