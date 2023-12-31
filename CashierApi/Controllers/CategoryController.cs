﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Concrete.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CashierApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("add")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Add(CategoryAddDto category)
        {
            var Addresult = await _categoryService.Add(category);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.MyMessage);
            }
            return BadRequest(Addresult.MyMessage);
        }

        [HttpDelete("delete")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(int categoryid)
        {
            var Addresult = await _categoryService.Delete(categoryid);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.MyMessage);
            }
            return BadRequest(Addresult.MyMessage);
        }

        [HttpPost("update")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Update(CategoryDto category)
        {
            var Addresult = await _categoryService.Update(category);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.MyMessage);
            }
            return BadRequest(Addresult.MyMessage);
        }

        [HttpGet("getbyid")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetById(int categoryid)
        {
            var Addresult = await _categoryService.GetById(categoryid);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.Data);
            }
            return BadRequest(Addresult.MyMessage);
        }
        [HttpGet("getall")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetList()
        {
            var result = await _categoryService.GetList();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.MyMessage);
        }
    }
}
