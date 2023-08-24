using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class ColorDetailDto:IDto
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }


    }
}
