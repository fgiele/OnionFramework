using Demo.Presentation.Shared;
using Demo.Process.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManageBasketController : Controller
    {
        private readonly IManageBasket _manageBasket;

        public ManageBasketController(IManageBasket manageBasket)
        {
            _manageBasket = manageBasket;
        }

        [HttpGet]
        public async Task<Basket?> GetByIdAsync(Guid Id)
        {
            var basketResult = await _manageBasket.GetAsync(Id);

            if(basketResult != null && basketResult.Status==ofw.process.ResultStatus.Success && basketResult.Value is Basket basket)
            {
                return basket;
            }
            else
            {
                return null;
            }
        }

        [HttpPut]
        public async Task<Basket?> SaveAsync(Basket basket)
        {
            var basketResult = await _manageBasket.SaveAsync(basket);

            if (basketResult != null && basketResult.Status == ofw.process.ResultStatus.Success && basketResult.Value is Basket returnedBasket)
            {
                return returnedBasket;
            }
            else
            {
                return null;
            }
        }
    }
}
