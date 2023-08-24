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
                                 BrandName = c.BrandName


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
    }
}
