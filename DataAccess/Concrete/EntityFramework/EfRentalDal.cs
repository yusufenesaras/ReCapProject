using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        // equals -> eşit ise
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join cr in context.Cars
                             on r.CarId equals cr.CarId
                             join cs in context.Customers
                             on r.CustomerId equals cs.CustomerId
                             join br in context.Brands
                             on cr.BrandId equals br.BrandId
                             join u in context.Users
                             on cs.UserId equals u.Id

                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 BrandName = br.BrandName,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,

                             };
                return result.ToList();
            }
        }
    }
}
