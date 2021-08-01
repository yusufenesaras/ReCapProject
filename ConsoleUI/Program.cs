using System;
using Business.Concrete;
using Entities.Concrete;
using System.Collections.Generic;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //Car car1 = new Car();
            //car1.Id = 2;
            //car1.BrandId = 2;
            //car1.CarName = "Kia";
            //car1.ColorId = 2;
            //car1.ModelYear = 2016;
            //car1.DailyPrice = 155000;
            //car1.Description = "Kia Rio 1.3 motor";
            //carManager.Add(car1);

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine($"Araba Adı: {car.CarName}\n" +
                    $"Araba Günlük Fiyatı: {car.DailyPrice}\n" +
                    $"Araba Markası: {car.BrandName}\n" +
                    $"Araba Rengi: {car.ColorName}");

            }

           /*
            * BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine($"Araba Markası: {brand.BrandName}\n");
            }

            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine($"Araba Rengi: {color.ColorName}\n");
            }
           */
        }
    }
}
