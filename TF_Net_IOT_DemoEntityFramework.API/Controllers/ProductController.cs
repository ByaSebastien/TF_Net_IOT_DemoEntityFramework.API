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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            Product product = await _productService.GetProduct(id);
            ProductDetailDto detail = product.ToProductDetail();
            return Ok(detail);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ProductFormDto form)
        {
            Product created = await _productService.Insert(form.ToProduct());
            return Ok(created.ToProductDetail());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductFormDto form)
        {
            Product updated = await _productService.Update(id, form.ToProduct());
            return Ok(updated.ToProductDetail());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Product deleted = await _productService.Delete(id);
            return Ok(deleted.ToProductDetail());
        }
    }
}
