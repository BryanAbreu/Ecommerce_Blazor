using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Contracts;
using System.Net.Http.Json;
using System.Reflection;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<SesionDTO>> Auth(LoginDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("User/Auth", model);
            var resutl = await response.Content.ReadFromJsonAsync<ResponseDTO<SesionDTO>>();

            return resutl!;
        }

        public async Task<ResponseDTO<UsuarioDTO>> Create(UsuarioDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("User/Create", model);
            var resutl = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();

            return resutl!;
        }

        public async Task<ResponseDTO<bool>> Delete(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"User/Delete/{id}");
        }

        public async Task<ResponseDTO<bool>> Edit(UsuarioDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("User/Edit", model);
            var resutl = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return resutl!;
        }
        public async Task<ResponseDTO<UsuarioDTO>> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>($"User/GetById/{id}");

        }

        public async Task<ResponseDTO<List<UsuarioDTO>>> List(string rol, string search)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UsuarioDTO>>>($"User/UserList/{rol}/{search}");
        }
    }
}
