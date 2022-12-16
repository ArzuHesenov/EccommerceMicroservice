using CatalogService.Business.Abstract;
using CatalogService.DataAccess.Abstract;
using CatalogService.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("gethomeall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetHomeProducts();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult Add(ProductDTO productDTO)
        {
            var result=_productService.AddProduct(productDTO);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("getbyid/{productId}")]
        public IActionResult GetById(string productGetById)
        {
            var result = _productService.GetProductById(productGetById);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
             return Ok(result);
        }
    }
}
