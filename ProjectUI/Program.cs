using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.VisualBasic;
using Core.Utilities.Security.Hashing;

internal class Program
{
    private static void Main(string[] args)
    {
        //RentalAddTest();

        CarManager carManager = new CarManager(new EfCarDal());
        
        var result = carManager.AddTransactionalTest(new Car
            { BrandId = 3002, ColorId = 1, DailyPrice = 400, ModelYear = 2000, Description = "Toros" });

        Console.WriteLine(result.Success);

    }

    private static void RentalAddTest()
    {
        RentalManager rentalManager = new RentalManager(new EfRentalDal());
        Console.WriteLine(rentalManager.Add(new Rental
        {
            Id = 2,
            CustomerId = 1,
            RentDate = new DateTime(2023, 02, 14)
            ,
            ReturnDate = new DateTime(0001, 01, 1),
            CarId = 1
        }).Message);
    }

    private static void CustomerAddTest()
    {
        CustomerManager customer1 = new CustomerManager(new EfCustomerDal());
        Console.WriteLine(customer1.Add(new Customer { CompanyName = "WOMENPOWER CORP", UserId = 3 }).Message);
    }

    //private static void UserAddTest()
    //{
    //    UserManager user1 = new UserManager(new EfUserDal());
    //    Console.WriteLine(user1.Add(new User { FirstName = "Hazal", LastName = "Baliç", Email = "hazalbalic@gmail.com", Password = "298547" }).Message);
    //}

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