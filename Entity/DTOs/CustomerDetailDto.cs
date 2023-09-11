using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class CustomerDetailDto
    {
        public int UserId { get; set; }

        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
    }
}
