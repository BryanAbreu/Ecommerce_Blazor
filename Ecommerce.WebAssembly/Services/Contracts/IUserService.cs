using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Contracts
{
    public interface IUserService
    {
        Task<ResponseDTO<List<UsuarioDTO>>> List(string rol, string search);
        Task<ResponseDTO<UsuarioDTO>> GetById(int id);
        Task<ResponseDTO<SesionDTO>> Auth(LoginDTO model);
        Task<ResponseDTO<UsuarioDTO>> Create(UsuarioDTO model);
        Task<ResponseDTO<bool>> Edit(UsuarioDTO model);
        Task<ResponseDTO<bool>> Delete(int id);

    }
}
