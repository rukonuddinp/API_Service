using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Service.Dtos
{
    public class ProductDtos
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Address { get; set; }
    }
}
