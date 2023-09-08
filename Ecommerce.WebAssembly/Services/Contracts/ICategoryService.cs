using Ecommerce.DTO;
namespace Ecommerce.WebAssembly.Services.Contracts
{
    public interface ICategoryService
    {
      
        Task<ResponseDTO<List<CategoriaDTO>>> List(string search);
        Task<ResponseDTO<CategoriaDTO>> GetById(int id);
        Task<ResponseDTO<CategoriaDTO>> Create(CategoriaDTO model);
        Task<ResponseDTO<bool>> Edit(CategoriaDTO model);
        Task<ResponseDTO<bool>> Delete(int id);

    }
}
