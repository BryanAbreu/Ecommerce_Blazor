using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Contracts;
using System.Net.Http.Json;
using System.Reflection;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<CategoriaDTO>> Create(CategoriaDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Category/Create", model);
            var resutl = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoriaDTO>>();

            return resutl!;
        }

        public async Task<ResponseDTO<bool>> Delete(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Category/Delete/{id}");
        }

        public async Task<ResponseDTO<bool>> Edit(CategoriaDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("Category/Edit", model);
            var resutl = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return resutl!;
        }

        public async Task<ResponseDTO<CategoriaDTO>> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<CategoriaDTO>>($"Category/GetById/{id}");
        }

        public async Task<ResponseDTO<List<CategoriaDTO>>> List(string search)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoriaDTO>>>($"Category/CategoryList/{search}");
        }
    }
}
