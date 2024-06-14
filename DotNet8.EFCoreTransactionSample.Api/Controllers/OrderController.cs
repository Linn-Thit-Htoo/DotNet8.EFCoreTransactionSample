using DotNet8.EFCoreTransactionSample.Api.Resources;
using DotNet8.EFCoreTransactionSample.DbService.Models;
using DotNet8.EFCoreTransactionSample.Mapper;
using DotNet8.EFCoreTransactionSample.Models.Setup.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace DotNet8.EFCoreTransactionSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly AppDbContext _appDbContext;

        public OrderController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitOrder([FromBody] OrderRequestModel requestModel)
        {
            var transaction = await _appDbContext.Database.BeginTransactionAsync();
            try
            {
                if (string.IsNullOrEmpty(requestModel.CustomerCode))
                    return BadRequest();

                if (requestModel.TotalAmount <= 0)
                    return BadRequest();

                if (requestModel.OrderDetails is null)
                    return BadRequest();

                var orderModel = requestModel.Change();
                await _appDbContext.TblOrders.AddAsync(orderModel);
                int orderResult = await _appDbContext.SaveChangesAsync();

                var orderDetailModel = requestModel
                    .OrderDetails.Select(x => new TblOrderDetail()
                    {
                        OrderDetailId = Guid.NewGuid().ToString(),
                        OrderId = orderModel.OrderId,
                        PricePerItem = x.PricePerItem,
                        ProductCode = x.ProductCode,
                        Quantity = x.Quantity,
                    })
                    .ToList();

                await _appDbContext.TblOrderDetails.AddRangeAsync(orderDetailModel);
                int result = await _appDbContext.SaveChangesAsync();

                if (orderResult > 0 && result > 0)
                {
                    await transaction.CommitAsync();
                    return Created();
                }

                await transaction.RollbackAsync();
                return BadRequest(MessageResource.SavingFail);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return HandleFailure(ex);
            }
        }
    }
}
