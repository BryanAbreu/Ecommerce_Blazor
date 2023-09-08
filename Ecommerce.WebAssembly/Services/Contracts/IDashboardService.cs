using Ecommerce.DTO;


namespace Ecommerce.WebAssembly.Services.Contracts
{
    public interface IDashboardService
    {
        Task<ResponseDTO<DashboardDTO>> Resume();
    }
}
