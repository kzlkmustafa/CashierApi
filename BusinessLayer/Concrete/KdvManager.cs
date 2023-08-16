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
    public class KdvManager : IKdvService
    {
        readonly private IKdvDal _kdvdal;
        readonly private IMapper _mapper;

        public KdvManager(IKdvDal kdvdal, IMapper mapper)
        {
            _kdvdal = kdvdal;
            _mapper = mapper;
        }

        public async Task<IResult> Add(KdvAddDto entity)
        {
            var result = _mapper.Map<Kdv>(entity);
            try
            {
                await _kdvdal.AddAsync(result);
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
        public async Task<IResult> Update(KdvDto entity)
        {
            var result = _mapper.Map<Kdv>(entity);
            try
            {
                await _kdvdal.UpdateAsync(result);
                return new Result(true, Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);

            }
        }

        public async Task<IDataResult<KdvDto>> GetById(int id)
        {
            try
            {
                Kdv entity = await _kdvdal.GetByIdAsync(x => x.KdvId == id);
                var result = _mapper.Map<KdvDto>(entity);
                return new DataResult<KdvDto>(result, true);

            }
            catch (Exception ex)
            {
                return new DataResult<KdvDto>(null, false, ex.Message);

            }
        }

        public async Task<IDataResult<IEnumerable<KdvDto>>> GetList()
        {
            try
            {
                IEnumerable<Kdv> entities = (await _kdvdal.GetAllAsync()).ToList();
                var result = _mapper.Map<IEnumerable<Kdv>, IEnumerable<KdvDto>>(entities);

                return new DataResult<IEnumerable<KdvDto>>(result, true,Messages.Succesfully);

            }
            catch (Exception ex)
            {
                return new DataResult<IEnumerable<KdvDto>>(null, false, ex.Message);

            }
        }

        
    }
}
