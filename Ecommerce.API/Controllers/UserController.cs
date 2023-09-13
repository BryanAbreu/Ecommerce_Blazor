using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.Services.Contract;
using Ecommerce.DTO;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
                
        }


        [HttpGet("UserList/{rol}/{search?}")]
        public async Task<IActionResult> List(string rol, string search="NA")
        {
            var response = new ResponseDTO<List<UsuarioDTO>>();

            try
            {
                if (search == "NA") search = "";
                response.EsCorrecto = true;
                response.Response = await _userService.List(rol, search);
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
            var response = new ResponseDTO<UsuarioDTO>();
            try
            {
                response.EsCorrecto = true;
                response.Response = await _userService.GetIDUser(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]UsuarioDTO model)
        {
            var response = new ResponseDTO<UsuarioDTO>();
            try
            {
                response.EsCorrecto = true;
                response.Response = await _userService.Create(model);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Auth")]
        public async Task<IActionResult> authorization([FromBody] LoginDTO model)
        {
            var response = new ResponseDTO<SesionDTO>();
            try
            {
                response.EsCorrecto = true;
                response.Response = await _userService.Auth(model);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] UsuarioDTO model)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.EsCorrecto = true;
                response.Response = await _userService.Edit(model);
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
                response.Response = await _userService.Delete(id);
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
