﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Concrete.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CashierApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BasketDetailController : ControllerBase
    {
        private readonly IBasketDetailService _basketDetailService;

        public BasketDetailController(IBasketDetailService basketDetailService)
        {
            _basketDetailService = basketDetailService;
        }

        [HttpPost("add")]

        [Authorize(Roles = "Cashier,Manager")]
        public async Task<IActionResult> Add(BasketDetailAddDto basketDetail)
        {
            var Addresult = await _basketDetailService.Add(basketDetail);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.MyMessage);
            }
            return BadRequest(Addresult.MyMessage);
        }

        [HttpDelete("delete")]

        [Authorize(Roles = "Cashier,Manager")]
        public async Task<IActionResult> Delete(int basketDetailid)
        {
            var Addresult = await _basketDetailService.Delete(basketDetailid);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.MyMessage);
            }
            return BadRequest(Addresult.MyMessage);
        }

        [HttpPost("update")]
        [Authorize(Roles = "Cashier,Manager")]
        public async Task<IActionResult> Update(BasketDetailDto basketDetail)
        {
            var Addresult = await _basketDetailService.Update(basketDetail);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.MyMessage);
            }
            return BadRequest(Addresult.MyMessage);
        }

        [HttpGet("getbyid")]
        [Authorize(Roles = "Cashier,Manager")]
        public async Task<IActionResult> GetById(int basketDetailid)
        {
            var Addresult = await _basketDetailService.GetById(basketDetailid);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.Data);
            }
            return BadRequest(Addresult.MyMessage);
        }

        [HttpGet("getall")]
        [Authorize(Roles = "Cashier,Manager")]
        //[Authorize(Roles = "Product.List")]
        public async Task<IActionResult> GetList()
        {
            var result = await _basketDetailService.GetList();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.MyMessage);
        }

        [HttpGet("getlistbybasketid")]
        [Authorize(Roles = "Cashier,Manager")]
        public async Task<IActionResult> GetBasketDetailsByBasketId(int basketid)
        {
            var Addresult = await _basketDetailService.GetListbyBasketId(basketid);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.Data);
            }
            return BadRequest(Addresult.MyMessage);
        }

        [HttpGet("getlistbyproductid")]
        [Authorize(Roles = "Cashier,Manager")]
        public async Task<IActionResult> GetBasketDetailsbyProductId(int productid)
        {
            var Addresult = await _basketDetailService.GetListbyProductId(productid);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.Data);
            }
            return BadRequest(Addresult.MyMessage);
        }
    }
}
