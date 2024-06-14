namespace DotNet8.EFCoreTransactionSample.Models.Setup.Order;

public class OrderModel
{
    public string OrderId { get; set; } = null!;

    public string CustomerCode { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public decimal Discount { get; set; }

    public DateTime OrderDate { get; set; }
}
