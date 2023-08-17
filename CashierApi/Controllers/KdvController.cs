using BusinessLayer.Abstract;
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
    public class KdvController : ControllerBase
    {
        private readonly IKdvService _kdvService;

        public KdvController(IKdvService kdvService)
        {
            _kdvService = kdvService;
        }

        [HttpPost("add")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Add(KdvAddDto kdv)
        {
            var Addresult = await _kdvService.Add(kdv);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.MyMessage);
            }
            return BadRequest(Addresult.MyMessage);
        }

        [HttpDelete("delete")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(int kdvid)
        {
            var Addresult = await _kdvService.Delete(kdvid);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.MyMessage);
            }
            return BadRequest(Addresult.MyMessage);
        }

        [HttpPost("update")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Update(KdvDto kdv)
        {
            var Addresult = await _kdvService.Update(kdv);
            if (Addresult.IsSuccess)
            {
                return Ok(Addresult.MyMessage);
            }
            return BadRequest(Addresult.MyMessage);
        }

        [HttpGet("getbyid")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetById(int kdvid)
        {
            var Addresult = await _kdvService.GetById(kdvid);
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
            var result = await _kdvService.GetList();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.MyMessage);
        }
    }
}
