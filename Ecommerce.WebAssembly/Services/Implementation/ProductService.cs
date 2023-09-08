using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Contracts;
using System.Net.Http.Json;
using System.Reflection;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class ProductService: IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<ProductoDTO>>> Catalog(string category, string search)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>($"Product/ProductList/{category}/{search}");
        }

        public async Task<ResponseDTO<ProductoDTO>> Create(ProductoDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Product/Create", model);
            var resutl = await response.Content.ReadFromJsonAsync<ResponseDTO<ProductoDTO>>();

            return resutl!;
        }

        public async Task<ResponseDTO<bool>> Delete(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Product/Delete/{id}");
        }

        public async Task<ResponseDTO<bool>> Edit(ProductoDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("Product/Edit", model);
            var resutl = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return resutl!;
        }

        public async Task<ResponseDTO<ProductoDTO>> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<ProductoDTO>>($"Product/GetById/{id}");
        }

        public async Task<ResponseDTO<List<ProductoDTO>>> List(string search)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>($"Product/ProductList/{search}");
        }
    }
}
