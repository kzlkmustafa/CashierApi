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
    public class CategoryManager : ICategoryService
    {
        readonly private ICategoryDal _categorydal;
        readonly private IMapper _mapper;

        public CategoryManager(ICategoryDal categorydal, IMapper mapper)
        {
            _categorydal = categorydal;
            _mapper = mapper;
        }

        public async Task<IResult> Add(CategoryAddDto entity)
        {
            var result = _mapper.Map<Category>(entity);
            try
            {
                await _categorydal.AddAsync(result);
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
                await _categorydal.DeleteAsync(id);
                return new Result(true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);

            }
        }
        public async Task<IResult> Update(CategoryDto entity)
        {
            var result = _mapper.Map<Category>(entity);
            try
            {
                await _categorydal.UpdateAsync(result);
                return new Result(true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);

            }
        }

        public async Task<IDataResult<CategoryDto>> GetById(int id)
        {
            try
            {
                Category entity = await _categorydal.GetByIdAsync(x => x.CategoryId == id);
                var result = _mapper.Map<CategoryDto>(entity);
                return new DataResult<CategoryDto>(result, true,Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new DataResult<CategoryDto>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<CategoryDto>>> GetList()
        {
            try
            {
                IEnumerable<Category> entities = (await _categorydal.GetAllAsync()).ToList();
                var result = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(entities);

                return new DataResult<IEnumerable<CategoryDto>>(result, true,Messages.Succesfully);

            }catch(Exception ex)
            {
                return new DataResult<IEnumerable<CategoryDto>>(null, false, ex.Message);

            }
        }

        
    }
}
