using DotNet8.EFCoreTransactionSample.DbService.Models;
using DotNet8.EFCoreTransactionSample.Models.Setup.Order;

namespace DotNet8.EFCoreTransactionSample.Mapper;

public static class ChangeModel
{
    public static TblOrder Change(this OrderRequestModel requestModel)
    {
        return new TblOrder
        {
            CustomerCode = requestModel.CustomerCode,
            Discount = requestModel.Discount,
            OrderId = Guid.NewGuid().ToString(),
            OrderDate = DateTime.Now,
            TotalAmount = requestModel.TotalAmount
        };
    }
}
