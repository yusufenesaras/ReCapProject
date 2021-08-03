using Business.Abstract;
using Business.Constans;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRule.Run(
               IsCarBeenDelivered(rental.CarId));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>
                (_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>
                (_rentalDal.Get(r => r.Id == id));
        }

        public IResult Update(Rental rental)
        {
            try
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentalUpdated);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.RentalUpdateError);
            }
        }

        // private metotlar
        private IResult IsCarBeenDelivered(int id)
        {
            var result = _rentalDal.Get(r => r.CarId == id && r.ReturnDate == null); 
            if (result == null)
            {
                return new SuccessResult(); 
            }
            return new ErrorResult("Araba teslim edilmemiş. Kiralama iptal.");
        }
    }
}
