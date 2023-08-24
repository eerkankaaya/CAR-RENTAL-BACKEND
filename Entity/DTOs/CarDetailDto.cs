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

    }
}
