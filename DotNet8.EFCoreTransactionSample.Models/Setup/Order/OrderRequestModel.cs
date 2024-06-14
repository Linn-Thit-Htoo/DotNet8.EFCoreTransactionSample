using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.EFCoreTransactionSample.Models.Setup.Order
{
    public class OrderRequestModel
    {
        public string CustomerCode { get; set; } = null!;

        public decimal TotalAmount { get; set; }

        public decimal Discount { get; set; }
        public List<OrderDetailRequestModel> OrderDetails { get; set; }
    }
}
