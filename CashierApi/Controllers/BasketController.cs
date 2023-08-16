using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Concrete.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashierApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Basket basket)
        {
            var result = new Basket();
            var Addresult = await _basketService.Add(basket);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.MyMessage);
            }
            return BadRequest(Addresult.MyMessage);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int basketid)
        {
            var Addresult = await _basketService.Delete(basketid);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.MyMessage);
            }
            return BadRequest(Addresult.MyMessage);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(Basket basket)
        {
            var Addresult = await _basketService.Update(basket);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.MyMessage);
            }
            return BadRequest(Addresult.MyMessage);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int basketid)
        {
            var Addresult = await _basketService.GetById(basketid);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.Data);
            }
            return BadRequest(Addresult.MyMessage);
        }
        [HttpGet("getall")]
        //[Authorize(Roles = "Product.List")]
        public async Task<IActionResult> GetList()
        {
            var result = await _basketService.GetList();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.MyMessage);
        }
        [HttpGet("getlistbycashierid")]
        public async Task<IActionResult> GetBasketsByCashierId(int cashierid)
        {
            var result = await _basketService.GetListByCashier(cashierid);
            if(result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.MyMessage);
        }
    }
}
