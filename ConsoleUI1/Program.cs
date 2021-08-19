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
            
            car.ModelYear = 1978;
            car.Description = "Şahin";
            car.DailyPrice = 100;

           // carManager.Add(car);//Ekleme

            //ColorManager colorManager1 = new ColorManager(new EfColorDal());
            //var result = colorManager1.GetColorId(1);

            //if (result.Success)

            //{
            //    Console.WriteLine(result.Message);
            //   Console.ReadLine();
            //}

            User user = new User();
            user.Id =2;
            
            user.LastName = "ATMACA";
            user.Email = "mismetatmaca@gmail.com";
            user.Password = "123456";

            //User user1 = new User();
            //user1.Id = 2;
            //user1.FirstName = "Arda";
            //user1.LastName = "ALİM";
            //user1.Email = "aaatmacagmail.com";
            //user1.Password = "987654"; 


             UserManager userManager = new UserManager(new EfUserDal());
             userManager.Add(user);
            // userManager.Add(user1);


            //Customer customer = new Customer();
            //customer.UserId = 1;
            //customer.CompanyName = "ATMACA";

            //Customer customer1 = new Customer();
            //customer1.UserId = 2;
            //customer1.CompanyName = "İnthermo";

            // CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            // customerManager.Add(customer);
            //// customerManager.Add(customer1);

            // Rental rental = new Rental();
            // rental.CarId = 1;
            // rental.CustomerId = 1;
            // rental.Id = 1;
            // rental.RentDate =new DateTime (1995, 11 , 11);

            // RentalManager rentalManager = new RentalManager(new EfRentalDal());
            // rentalManager.Add(rental);




            //var result = carManager.GetCarDetails();

            //if (result.Success == true)
            //{
            //    foreach (var carDetails in result.Data)
            //    {
            //        Console.WriteLine("Marka Adı: " + carDetails.BrandName + "/ " + "Renk:" + carDetails.ColorName + "/ "
            //            + "Günlük Fiyatı: " + carDetails.DailyPrice);
            //    }
            //}
            //else
            //{

            //    Console.WriteLine(result.Message);

            //}
            //}



            //   carManager.Delete(car);//Silme
            //    carManager.Update(car);//Güncelleme

            //  GetAll(carManager);//Tüm Listeyi Getir
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












            //private static void GetCarsByColorId(CarManager carManager)
            //{
            //    foreach (var cars in carManager.GetCarsByColorId(1).Data)
            //    {
            //        Console.WriteLine(cars.DailyPrice);
            //    }
            //}

            //private static void GetCarsById(CarManager carManager)
            //{
            //    foreach (var cars in carManager.GetCarsByBrandId(1).Data)
            //    {
            //        Console.WriteLine(cars.Description);
            //    }
            //}

            //private static void GetAll(CarManager carManager)
            //{
            //    foreach (var item in carManager.GetAll().Data)//Bütün Listeyi Yazdırma
            //    {
            //        Console.WriteLine(item.Description +"/"+ item.ModelYear+"/"+item.DailyPrice);

            //    }
            //}
            //private static void GetColorId(ColorManager colorManager)
            //{

            //}
        }
    }
}
