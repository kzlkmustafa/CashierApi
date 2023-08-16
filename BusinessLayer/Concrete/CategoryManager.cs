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
    public class CategoryManager : ICategoryService
    {
        readonly private ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        public async Task<IResult> Add(Category entity)
        {
            try
            {
                await _categorydal.AddAsync(entity);
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

        public async Task<IDataResult<Category>> GetById(int id)
        {
            try
            {
                Category category = await _categorydal.GetByIdAsync(x => x.CategoryId == id);
                return new DataResult<Category>(category, true,Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new DataResult<Category>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<Category>>> GetList()
        {
            try
            {
                IEnumerable<Category> categories = (await _categorydal.GetAllAsync()).ToList();
                return new DataResult<IEnumerable<Category>>(categories, true,Messages.Succesfully);

            }catch(Exception ex)
            {
                return new DataResult<IEnumerable<Category>>(null, false, ex.Message);

            }
        }

        public async Task<IResult> Update(Category entity)
        {
            try
            {
                await _categorydal.UpdateAsync(entity);
                return new Result(true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);

            }
        }
    }
}
