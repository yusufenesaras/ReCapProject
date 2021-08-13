using System;
using Business.Concrete;
using Entities.Concrete;
using System.Collections.Generic;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using Core.Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarsAddTest(carManager);
            //CarsInfoListed(carManager);
            //UserAddTest(userManager);
            //CustomerAddTest();
            //RentalRentTest();
        }

        private static void RentalRentTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental rental1 = new Rental();
            rental1.CarId = 1;
            rental1.CustomerId = 1;
            rental1.RentDate = new DateTime(2021, 08, 13);
            rental1.ReturnDate = new DateTime(2021, 09, 13);


            var result = rentalManager.Delete(rental1);
            Console.WriteLine(result.Message);
        }

        private static void CustomerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer1 = new Customer();
            customer1.CustomerId = 1;
            customer1.UserId = 1;
            customer1.CompanyName = "Starlink";
            customerManager.Add(customer1);
        }

        private static void UserAddTest(UserManager userManager)
        {
            User user1 = new User();
            user1.FirstName = "Yusuf Enes";
            user1.LastName = "Aras";
            //user1.Password = "12345";
            user1.Email = "enesaras551@gmail.com";
            userManager.Add(user1);
        }

        private static void CarsAddTest(CarManager carManager)
        {
            Car car1 = new Car();
            car1.CarName = "Kia Rio";
            car1.ModelYear = 2016;
            car1.DailyPrice = 155000;
            car1.Description = "Kia Rio 1.3 motor";
            carManager.Add(car1);
        }

        private static void CarsInfoListed(CarManager carManager)
        {
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine($"Araba Adı: {car.CarName}\n" +
                        $"Araba Günlük Fiyatı: {car.DailyPrice}\n" +
                        $"Araba Markası: {car.BrandName}\n" +
                        $"Araba Rengi: {car.ColorName}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
