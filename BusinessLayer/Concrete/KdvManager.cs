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
    public class KdvManager : IKdvService
    {
        readonly private IKdvDal _kdvdal;

        public KdvManager(IKdvDal kdvdal)
        {
            _kdvdal = kdvdal;
        }

        public async Task<IResult> Add(Kdv entity)
        {
            try
            {
                await _kdvdal.AddAsync(entity);
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
                await _kdvdal.DeleteAsync(id);
                return new Result(true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);

            }
        }

        public async Task<IDataResult<Kdv>> GetById(int id)
        {
            try
            {
                Kdv mykdvdetail = await _kdvdal.GetByIdAsync(x => x.KdvId == id);
                return new DataResult<Kdv>(mykdvdetail, true);

            }
            catch (Exception ex)
            {
                return new DataResult<Kdv>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<Kdv>>> GetList()
        {
            try
            {
                IEnumerable<Kdv> mykdvdetail = (await _kdvdal.GetAllAsync()).ToList();
                return new DataResult<IEnumerable<Kdv>>(mykdvdetail, true,Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new DataResult<IEnumerable<Kdv>>(null, false, ex.Message);

            }
        }

        public async Task<IResult> Update(Kdv entity)
        {
            try
            {
                await _kdvdal.UpdateAsync(entity);
                return new Result(true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);

            }
        }
    }
}
