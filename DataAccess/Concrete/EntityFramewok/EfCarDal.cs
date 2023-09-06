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
                var result = from p in context.Cars
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             select new ColorDetailDto
                             {
                                 ColorId = c.ColorId,
                                 ColorName = c.ColorName,
                                 BrandName = c.BrandName,
                                

                             };
                return result.ToList();



            }

        }
        public List<BrandDetailDto> GetBrandDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from p in context.Cars
                             join c in context.Brands
                             on p.BrandId equals c.BrandId
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
