using Blazored.LocalStorage;
using Ecommerce.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Ecommerce.WebAssembly.Extensions
{
    public class AuthExtension : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private ClaimsPrincipal _SingInfo = new ClaimsPrincipal(new ClaimsIdentity());
        public AuthExtension(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sessUser = await _localStorageService.GetItemAsync<SesionDTO>("UserSession");
            if (sessUser == null) 
            {
                return await Task.FromResult(new AuthenticationState(_SingInfo));
            }
            var claimsprincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,sessUser.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Name,sessUser.NombreCompleto),
                    new Claim(ClaimTypes.Email,sessUser.Correo),
                    new Claim(ClaimTypes.Role,sessUser.Rol)

                }, "jwtAuth"));
            return await Task.FromResult(new AuthenticationState(claimsprincipal));
        }

        public async Task UpbateStateAuth(SesionDTO? sessUser)
        {
            ClaimsPrincipal claimsPrincipal;

            if (sessUser != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,sessUser.IdUsuario.ToString()),
                    new Claim(ClaimTypes.NameIdentifier,sessUser.NombreCompleto),
                    new Claim(ClaimTypes.NameIdentifier,sessUser.Correo),
                    new Claim(ClaimTypes.NameIdentifier,sessUser.Rol)

                }, "jwtAuth"));

                await _localStorageService.SetItemAsync("UserSession", sessUser);
            }
            else
            {
                claimsPrincipal = _SingInfo;
                await _localStorageService.RemoveItemAsync("UserSession");
            
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));



        }

    }
}
