using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.Services.Contract;
using Ecommerce.DTO;
using Ecommerce.Services.Implementation;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _DashService;

        public DashboardController(IDashboardService DashService)
        {
            _DashService = DashService;
        }

        [HttpGet("Resume")]
        public IActionResult Resume()
        {
            var response = new ResponseDTO<DashboardDTO>();
            try
            {
                response.EsCorrecto = true;
                response.Response =  _DashService.Resume();
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
