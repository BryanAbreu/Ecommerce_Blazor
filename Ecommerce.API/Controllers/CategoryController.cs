using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.Services.Contract;
using Ecommerce.DTO;
using Ecommerce.Services.Implementation;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IcategorySevice _categoryService;

        public CategoryController(IcategorySevice categoryService)
        {
            _categoryService = categoryService;

        }

        [HttpGet("CategoryList/{search?}")]
        public async Task<IActionResult> List(string search = "NA")
        {
            var response = new ResponseDTO<List<CategoriaDTO>>();

            try
            {
                if (search == "NA") search = "";
                response.EsCorrecto = true;
                response.Response = await _categoryService.List( search);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = new ResponseDTO<CategoriaDTO>();
            try
            {
                response.EsCorrecto = true;
                response.Response = await _categoryService.GetIDCategory(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CategoriaDTO model)
        {
            var response = new ResponseDTO<CategoriaDTO>();
            try
            {
                response.EsCorrecto = true;
                response.Response = await _categoryService.Create(model);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] CategoriaDTO model)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.EsCorrecto = true;
                response.Response = await _categoryService.Edit(model);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.EsCorrecto = true;
                response.Response = await _categoryService.Delete(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }
    }
}
