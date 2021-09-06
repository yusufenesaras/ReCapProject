using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        // equals -> eşit ise
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            
                using (ReCapContext context = new ReCapContext())
                {
                    var result = from c in context.Cars
                                 join b in context.Brands
                                 on c.BrandId equals b.BrandId
                                 join co in context.Colors
                                 on c.ColorId equals co.ColorId
                                 select new CarDetailDto
                                 {
                                     Id = c.CarId,
                                     BrandId = c.BrandId,
                                     ColorId = c.ColorId,
                                     CarName = c.CarName,
                                     BrandName = b.BrandName,
                                     ColorName = co.ColorName,
                                     DailyPrice = c.DailyPrice,
                                     ModelYear = c.ModelYear,
                                     Description = c.Description,
                                     CarImage = (from i in context.CarImages
                                                 where (c.CarId == i.CarId)
                                                 select new CarImage
                                                 { CarImageId = i.CarImageId,
                                                     CarId = c.CarId,
                                                     UploadDate = i.UploadDate,
                                                     ImagePath = i.ImagePath 
                                                 }).ToList()
                                 };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            };
        }
    }
}
