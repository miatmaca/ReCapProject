using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager car = new CarManager(new EfCarDal());

            foreach (var cars in car.GetCarsByBrandId(1))
            {
                Console.WriteLine(cars.Description);
            }
            foreach (var cars in car.GetCarsByColorId(1))
            {
                Console.WriteLine(cars.DailyPrice);
            }
        }
    }
}
