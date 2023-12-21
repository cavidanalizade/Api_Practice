using App.BUSINESS.DTOs.Brand;
using App.BUSINESS.Services.Interfaces;
using App.CORE.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _service;

        public BrandController(IBrandService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var brands = await  _service.GetAllAsync();
            return StatusCode(StatusCodes.Status200OK, brands);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById (int id)
        {
            Brand brand = await _service.GetById(id);
            return StatusCode(StatusCodes.Status200OK, brand);
        }
        [HttpPost]
        public async Task <IActionResult> Create ([FromForm]CreateBrandDto createBrandDto)
        {
            await _service.Create(createBrandDto);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateBrandDto updateBrandDto)
        {
            await _service.Update(updateBrandDto);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpDelete("id")]

        public async Task<IActionResult> Delete( int id)
        {
           await  _service.Delete(id);
            return StatusCode(StatusCodes.Status200OK);

        }
        [HttpGet("RecycleBin")]
        public async Task<IActionResult> RecycleBin()
        {
            var brands = await _service.RecycleBin();
            return StatusCode(StatusCodes.Status200OK, brands);

        }
    }
}
