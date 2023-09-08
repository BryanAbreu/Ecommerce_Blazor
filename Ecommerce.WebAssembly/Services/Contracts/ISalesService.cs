using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Contracts
{
    public interface ISalesService
    {
        Task<ResponseDTO<VentaDTO>> Registre(VentaDTO model);
    }
}
