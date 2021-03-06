using Business.Abstract;
using Business.Constans;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        
        public IResult Add(Brand brand)
        {
           _brandDal.Add(brand);
           return new SuccessResult(Messages.BrandAdded);
            
        }
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new Result(true, Messages.BrandDeleted);
        }
        [CacheAspect] //key, value
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>
                (_brandDal.GetAll(), Messages.BrandListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>
                (_brandDal.Get(b => b.BrandId == id));
        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandName == null)
            {
                return new ErrorResult(Messages.BrandNameNull);
            }
            _brandDal.Update(brand);
            return new Result(true, Messages.BrandUpdated);
        }
    }
}
