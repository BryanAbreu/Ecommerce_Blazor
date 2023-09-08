using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Contracts
{
    public interface IProductService
    {
        Task<ResponseDTO<List<ProductoDTO>>> List(string search);
        Task<ResponseDTO<List<ProductoDTO>>> Catalog(string category,string search);
        Task<ResponseDTO<ProductoDTO>> GetById(int id);
        Task<ResponseDTO<ProductoDTO>> Create(ProductoDTO model);
        Task<ResponseDTO<bool>> Edit(ProductoDTO model);
        Task<ResponseDTO<bool>> Delete(int id);

    }
}
