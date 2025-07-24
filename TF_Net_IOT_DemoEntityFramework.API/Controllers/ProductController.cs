using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TF_Net_IOT_DemoEntityFramework.API.Dtos.Products;
using TF_Net_IOT_DemoEntityFramework.API.Mappers;
using TF_Net_IOT_DemoEntityFramework.BLL.Services;
using TF_Net_IOT_DemoEntityFramework.DAL.Entities;

namespace TF_Net_IOT_DemoEntityFramework.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            List<Product> products = await _productService.GetProducts();
            List<ProductIndexDto> dtos = products.Select(p => p.ToProductIndex()).ToList();
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ProductCreateFormDto form)
        {
            Product created = await _productService.Insert(form.ToProduct());
            return Ok(created.ToProductDetail());
        }
    }
}
