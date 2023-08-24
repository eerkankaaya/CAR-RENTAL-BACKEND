using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Car:IEntity
    {
        public int BrandId { get; set; }
        public int ColorId  { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitPrice { get; set; }
    }
}
