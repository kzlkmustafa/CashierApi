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
    public class ProductManager : IProductService
    {
        readonly private IProductDal _productdal;
        readonly private IMapper _mapper;

        public ProductManager(IProductDal productdal, IMapper mapper)
        {
            _productdal = productdal;
            _mapper = mapper;
        }

        public async Task<IResult> Add(ProductAddDto entity)
        {
            var result = _mapper.Map<Product>(entity);
            try
            {
                await _productdal.AddAsync(result);
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
        public async Task<IResult> Update(ProductDto entity)
        {

            var result = _mapper.Map<Product>(entity);
            try
            {
                await _productdal.UpdateAsync(result);
                return new Result(true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }

        }

        public async Task<IDataResult<ProductDto>> GetById(int id)
        {
            try
            {
                Product entity = await _productdal.GetByIdAsync(x => x.ProductId == id);
                var result = _mapper.Map<ProductDto>(entity);
                return new DataResult<ProductDto>(result, true, Messages.Succesfully);
            }
            catch (Exception ex)
            {
                return new DataResult<ProductDto>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<ProductDto>>> GetList()
        {
            try
            {
                IEnumerable<Product> entity = (await _productdal.GetAllAsync()).ToList();
                var result = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(entity);
                return new DataResult<IEnumerable<ProductDto>>(result, true, Messages.Succesfully);
            }
            catch (Exception ex)
            {
                return new DataResult<IEnumerable<ProductDto>>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<ProductDto>>> GetListByCategoryId(int categoryId)
        {
            try
            {
                IEnumerable<Product> entity = (await _productdal.GetAllAsync(x => x.CategoryId == categoryId)).ToList();
                var result = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(entity);
                return new DataResult<IEnumerable<ProductDto>>(result, true, Messages.Succesfully);
            }
            catch (Exception ex)
            {
                return new DataResult<IEnumerable<ProductDto>>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<ProductDto>>> GetListByKdvId(int kdvId)
        {
            try
            {
                IEnumerable<Product> entity = (await _productdal.GetAllAsync(x => x.CategoryId == kdvId)).ToList();
                var result = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(entity);
                return new DataResult<IEnumerable<ProductDto>>(result, true, Messages.Succesfully);
            }
            catch (Exception ex)
            {
                return new DataResult<IEnumerable<ProductDto>>(null, false, ex.Message);

            }
        }

        
    }
}
