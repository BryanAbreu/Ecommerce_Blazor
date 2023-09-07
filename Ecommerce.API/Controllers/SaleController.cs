using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.Services.Contract;
using Ecommerce.DTO;
using Ecommerce.Services.Implementation;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IVentaService _VentaService;

        public SaleController(IVentaService VentaService)
        {
            _VentaService = VentaService;
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Registre([FromBody] VentaDTO model)
        {
            var response = new ResponseDTO<VentaDTO>();
            try
            {
                response.EsCorrecto = true;
                response.Response = await _VentaService.Registre(model);
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
