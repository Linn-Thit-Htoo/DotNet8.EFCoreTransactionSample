using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.EFCoreTransactionSample.Models.Setup.Order
{
    public class OrderDetailRequestModel
    {
        public string ProductCode { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal PricePerItem { get; set; }
    }
}
