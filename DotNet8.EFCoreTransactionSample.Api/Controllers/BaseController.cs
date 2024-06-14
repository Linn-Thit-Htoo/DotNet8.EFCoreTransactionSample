using DotNet8.EFCoreTransactionSample.Api.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.EFCoreTransactionSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult Created()
        {
            return StatusCode(201, MessageResource.SavingSuccessful);
        }

        protected IActionResult HandleFailure(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
