namespace DotNet8.EFCoreTransactionSample.Models.Setup.Order
{
    public class OrderDetailModel
    {
        public string OrderDetailId { get; set; } = null!;

        public string OrderId { get; set; } = null!;

        public string ProductCode { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal PricePerItem { get; set; }
    }
}
