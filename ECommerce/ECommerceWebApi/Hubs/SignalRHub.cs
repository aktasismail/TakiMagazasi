using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Data;
using Microsoft.AspNetCore.SignalR;

namespace ECommerceWebApi.Hubs
{
	public class SignalRHub:Hub
	{
		private readonly IProductService _productService;
        public SignalRHub(IProductService productService)
        {
            _productService = productService;
        }

        public async Task SendStacistic()
		{
			var productcountvalue = _productService.TProductCount();
			await Clients.All.SendAsync("ProductCount", productcountvalue);
			var productmaxvalue = _productService.TProductNameByMaxPrice();
			await Clients.All.SendAsync("ProductMaxPrice", productmaxvalue);
            var productminvalue = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ProductMinPrice", productminvalue);
            var productpriceavg = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ProductPriceAvg", productpriceavg);
        }
     
    }
}
