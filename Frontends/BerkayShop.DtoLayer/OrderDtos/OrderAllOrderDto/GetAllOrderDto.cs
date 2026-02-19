using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayShop.DtoLayer.OrderDtos.OrderAllOrderDto
{
    public class GetAllOrderDto
    {
        public int orderingId { get; set; }
        public string userId { get; set; }
        public float totalPrice { get; set; }
        public DateTime orderDate { get; set; }
    }
}
