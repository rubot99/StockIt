using Microsoft.AspNetCore.Mvc;
using StockIt.Core.Repositories.Product;
using StockIt.Mvc.Services;
using System.Threading.Tasks;

namespace StockIt.Mvc.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductDataService productDataService;

        public ProductController(IProductDataService productDataService)
        {
            this.productDataService = productDataService;
        }
        public async Task<IActionResult> Index()
        {
            var productList = await productDataService.GetAllAsync(base.Teanat).ConfigureAwait(false);
            return View(productList);
        }

        public async Task<IActionResult> Delete(string id, string tenant)
        {
            var product = await productDataService.GetAsync(id, tenant).ConfigureAwait(false);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            await productDataService.DeleteAsync(product.Id, base.Teanat).ConfigureAwait(false);
            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> Edit(string id, string tenant)
        {
            var product = await productDataService.GetAsync(id, tenant).ConfigureAwait(false);
            return View(product);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            product.Enabled = true;
            product.Tenant = base.Teanat;
            await productDataService.AddAsync(product).ConfigureAwait(false);
            return RedirectToAction("Index", "Product");
        }
    }
}
