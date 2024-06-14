namespace DotNet8.EFCoreTransactionSample.Models.Setup.Order;

public class OrderRequestModel
{
    public string CustomerCode { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public decimal Discount { get; set; }
    public List<OrderDetailRequestModel> OrderDetails { get; set; }
}
