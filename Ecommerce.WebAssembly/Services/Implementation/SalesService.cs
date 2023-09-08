using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Contracts;
using System.Net.Http.Json;
using System.Reflection;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class SalesService : ISalesService
    {
        private readonly HttpClient _httpClient;
        public SalesService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<VentaDTO>> Registre(VentaDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Sale/Create", model);
            var resutl = await response.Content.ReadFromJsonAsync<ResponseDTO<VentaDTO>>();

            return resutl!;
        }
    }
}
