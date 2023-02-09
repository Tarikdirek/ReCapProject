using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new EfCarDal());

        foreach (var car in carManager.GetCarDetails())
        {
            Console.WriteLine(car.Descriptoin + "---" + car.BrandName + "----" + car.ColorName);
        }

    }


}