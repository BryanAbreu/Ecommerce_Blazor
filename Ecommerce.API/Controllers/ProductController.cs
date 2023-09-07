using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.Services.Contract;
using Ecommerce.DTO;
using Ecommerce.Services.Implementation;

namespace Ecommerce.API.Controllers
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

        [HttpGet("ProductList/{search:alpha?}")]
        public async Task<IActionResult> List(string search = "NA")
        {
            var response = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                if (search == "NA") search = "";
                response.EsCorrecto = true;
                response.Response = await _productService.List(search);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("Catalog/{category:alpha}/{search:alpha?}")]
        public async Task<IActionResult> Cataglog(string category,string search = "NA")
        {
            var response = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                if (category.ToLower() == "Todos") category = "";
                if (search == "NA") search = "";
                response.EsCorrecto = true;
                response.Response = await _productService.catalog(category,search);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("GetById{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = new ResponseDTO<ProductoDTO>();
            try
            {
                response.EsCorrecto = true;
                response.Response = await _productService.GetProductID(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ProductoDTO model)
        {
            var response = new ResponseDTO<ProductoDTO>();
            try
            {
                response.EsCorrecto = true;
                response.Response = await _productService.Create(model);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] ProductoDTO model)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.EsCorrecto = true;
                response.Response = await _productService.Edit(model);
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
                response.Response = await _productService.Delete(id);
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
