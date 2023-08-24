using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class BrandDetailDto:IDto
    {

        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int BrandId { get; set; }
    }
}
