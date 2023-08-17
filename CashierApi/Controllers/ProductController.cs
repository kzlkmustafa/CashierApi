using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Concrete.Dto;
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
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> AddProduct(ProductAddDto product)
        {
            var Addresult = await _productService.Add(product);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.MyMessage);
            }
            return BadRequest(Addresult.MyMessage);
        }
        [HttpDelete("delete")]
        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Update(ProductDto product)
        {
            var Addresult = await _productService.Update(product);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.MyMessage);
            }
            return BadRequest(Addresult.MyMessage);
        }

        [HttpGet("getbyid")]
        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
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
