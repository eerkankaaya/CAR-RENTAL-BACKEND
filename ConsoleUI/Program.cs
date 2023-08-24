// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramewok;



public class Program
{
    private static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new EfCarDal());
        var result = carManager.GetColorDetails();

        if (result.Success == true)
        {
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.ColorId + "/" + car.ColorName + "/" + car.BrandName);
                Console.WriteLine(result.Success);
            }
        }
        //foreach (var car in carManager.GetBrandDetails())
        //{
        //    Console.WriteLine(car.BrandId + "/" + car.BrandName + "/" + car.ColorName);

        //}


        else
        {
            Console.WriteLine(result.Message);


        };
    }

}