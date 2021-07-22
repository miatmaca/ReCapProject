using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            Car car = new Car();
            car.BrandId = 1;
            car.ColorId = 3;
            car.Id = 4;
            car.ModelYear = 1999;
            car.Description = "Tofaş";
            car.DailyPrice = 100;

            foreach (var carDetails in carManager.GetCarDetails())
            {
                Console.WriteLine(carDetails.BrandName+"/"+carDetails.Description+"/"+carDetails.ColorName);

            }


            //  carManager.Add(car);//Ekleme
            //   carManager.Delete(car);//Silme
            //    carManager.Update(car);//Güncelleme

            // GetAll(carManager);//Tüm Listeyi Getir
            // GetCarsById(carManager);//Araba Id'sine Göre Listele
            // GetCarsByColorId(carManager);//Araba Renk Bilgisine Göre Listele



            //BrandManager brandManager = new BrandManager(new EfBrandDal());

            //Brand brand = new Brand();
            //brand.BrandId = 8;
            //brand.BrandName = "Doğan";
            //brandManager.Add(brand);

            //foreach (var brands in brandManager.GetAll())
            //{
            //    Console.WriteLine(brands.BrandName);
            //}


          

        }







        private static void GetCarsByColorId(CarManager carManager)
        {
            foreach (var cars in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(cars.DailyPrice);
            }
        }

        private static void GetCarsById(CarManager carManager)
        {
            foreach (var cars in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(cars.Description);
            }
        }

        private static void GetAll(CarManager carManager)
        {
            foreach (var item in carManager.GetAll())//Bütün Listeyi Yazdırma
            {
                Console.WriteLine(item.Description + item.ModelYear);

            }
        }
    }
}
