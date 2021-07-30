using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>()
            {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2015,DailyPrice=175,Description="KIA"},
                new Car{Id=2,BrandId=1,ColorId=2,ModelYear=2020,DailyPrice=200,Description="BMW"},
                new Car{Id=3,BrandId=2,ColorId=2,ModelYear=2018,DailyPrice=125,Description="FORD"},
                new Car{Id=4,BrandId=3,ColorId=2,ModelYear=2020,DailyPrice=180,Description="Audi"},
                new Car{Id=5,BrandId=4,ColorId=3,ModelYear=2021,DailyPrice=250,Description="Mercedes"}
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _car.SingleOrDefault(c => c.Id == car.Id);
            _car.Remove(CarToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _car.Where(c => c.Id == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
