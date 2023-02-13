using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.VisualBasic;

internal class Program
{
    private static void Main(string[] args)
    {
        //CarDetailsTest();
        //CarAddTest();
        //BrandGetAllTest();
        //ColorGetAllTest();

        ColorUpdateTest();
    }

    private static void ColorUpdateTest()
    {
        ColorManager colorManager = new ColorManager(new EfColorDal());
        Console.WriteLine(colorManager.Update(new Color { ColorId = 2004, ColorName = "Yellow" }).Message);
    }

    private static void ColorGetAllTest()
    {
        ColorManager colorManager = new ColorManager(new EfColorDal());

        foreach (var color in colorManager.GetAll().Data)
        {
            Console.WriteLine(color.ColorName);
        }
    }

    private static void BrandGetAllTest()
    {
        BrandManager brandManager = new BrandManager(new EfBrandDal());

        foreach (var brand in brandManager.GetAll().Data)
        {
            Console.WriteLine(brand.BrandName);
        }
    }

    private static void CarAddTest()
    {
        CarManager carManager1 = new CarManager(new EfCarDal());
        var result = carManager1.Add(new Car { BrandId = 2, ColorId = 3, DailyPrice = 1200, Description = "a", ModelYear = 2018 });
        Console.WriteLine(result.Message);
    }

    private static void CarDetailsTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());

        var result = carManager.GetCarDetails();

        if (result.Success == true)
        {
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.Descriptoin + "---" + car.BrandName + "----" + car.ColorName);
            }

        }
        else
        {
            Console.WriteLine(result.Message);
        }


    }
}