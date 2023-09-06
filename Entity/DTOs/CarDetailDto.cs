using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitPrice { get; set; }
        public string CarName { get; set; }
        public string ImagePath { get; set; }
        public int ColorId { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int BrandId { get; set; }

    }
}
