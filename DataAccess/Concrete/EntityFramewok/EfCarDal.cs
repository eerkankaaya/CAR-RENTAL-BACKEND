using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramewok
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<ColorDetailDto> GetColorDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Colors
                             
                             select new ColorDetailDto
                             {
                                 ColorId = c.ColorId,
                                 ColorName = c.ColorName,
                                 BrandName = c.BrandName,
                                

                             };
                return result.ToList();



            }

        }
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Rentals
                             join b in context.Brands
                             on c.CarId equals b.CarId
                             join co in context.Users
                             on c.CustomerId equals co.CustomerId
                             select new RentalDetailDto
                             {
                                 
                                 BrandName=b.BrandName,
                                 FirstName=co.FirstName,
                                 LastName=co.LastName,
                                 RentDate = c.RentDate,
                                 ReturnDate = c.ReturnDate,

                             };
                return result.ToList();



            }
        }
            public List<CustomerDetailDto> GetCustomerDetails()
            {
                using (CarContext context = new CarContext())
                {
                    var result = from c in context.Customers
                                 
                                  
                                 select new CustomerDetailDto
                                 {
                                     CustomerId = c.CustomerId,
                                     CompanyName = c.CompanyName,
                                     UserId = c.UserId, 

                                     
                                 };
                    return result.ToList();



                }

            }
        public List<BrandDetailDto> GetBrandDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = 
                             from c in context.Brands
                             
                             select new BrandDetailDto
                             {
                                 BrandName = c.BrandName,
                                 BrandId = c.BrandId,
                                 ColorName = c.ColorName,

                             };
                return result.ToList();



            }


        }
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId

                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 UnitsInStock=c.UnitsInStock,
                                 UnitPrice = c.UnitPrice,

                                 CarName=c.CarName,
                                 BrandId = b.BrandId,
                                 
                                 ColorId = co.ColorId,
                                 
                                 ImagePath = (from m in context.CarImages where m.CarId == c.CarId select m.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

    }
}
