using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CashierApi.Controllers
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

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var Addresult = await _productService.Add(product);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.MyMessage);
            }
            return BadRequest(Addresult.MyMessage);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteProduct(int productid)
        {
            var Addresult = await _productService.Delete(productid);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.MyMessage);
            }
            return BadRequest(Addresult.MyMessage);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(Product product)
        {
            var Addresult = await _productService.Update(product);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.MyMessage);
            }
            return BadRequest(Addresult.MyMessage);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdProduct(int productid)
        {
            var Addresult = await _productService.GetById(productid);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.Data);
            }
            return BadRequest(Addresult.MyMessage);
        }
        [HttpGet("getall")]
        //[Authorize(Roles = "Product.List")]
        public async Task<IActionResult> GetListProduct()
        {
            var result = await _productService.GetList();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.MyMessage);
        }

        [HttpGet("getlistbycategoryid")]
        public async Task<IActionResult> GetProductsByCategoryId(int categoryid)
        {
            var Addresult = await _productService.GetListByCategoryId(categoryid);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.Data);
            }
            return BadRequest(Addresult.MyMessage);
        }

        [HttpGet("getlistbykdvid")]
        public async Task<IActionResult> GetProductsByKdvId(int kdvid)
        {
            var Addresult = await _productService.GetListByKdvId(kdvid);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.Data);
            }
            return BadRequest(Addresult.MyMessage);
        }

        
    }
}
