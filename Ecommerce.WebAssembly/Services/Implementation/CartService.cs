using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Contracts;
using System.Net.Http.Json;
using System.Reflection;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class CartService : ICartService
    {
        private ILocalStorageService _localStorageService;
        private ISyncLocalStorageService _syncLocalStorageService;
        private IToastService _toastService;

        public CartService(ILocalStorageService localStorageService, ISyncLocalStorageService syncLocalStorageService, IToastService toastService)
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService;
            _toastService = toastService;
        }

        public event Action ShowItems;

        public async Task AddToCart(CarritoDTO model)
        {
            try
            {
                var cart = await _localStorageService.GetItemAsync<List<CarritoDTO>>("Cart");
                if (cart == null) cart = new List<CarritoDTO>();

                var items = cart.FirstOrDefault(x => x.producto.IdProducto == model.producto.IdProducto);
                if (items == null) cart.Remove(items);
              
                cart.Add(model);
                await _localStorageService.SetItemAsync("cart", cart);

                if (items != null)
                    _toastService.ShowSuccess("Product was update to cart");
                else
                    _toastService.ShowSuccess("Product was add to cart");

                ShowItems.Invoke();
            }
            catch (Exception)
            {
                _toastService.ShowError("cant add to cart");
            }
        }
        public int CartAmount()
        {
            var cart = _syncLocalStorageService.GetItem<List<CarritoDTO>>("cart");

            return cart== null ? 0 : cart.Count();
        }

        public async Task Clearcart()
        {
            await _localStorageService.RemoveItemAsync("cart");
            ShowItems.Invoke();
        }

        public async Task DelteToCart(int id)
        {
            try
            {
                var cart = await _localStorageService.GetItemAsync<List<CarritoDTO>>("cart");
                if (cart != null)
                {
                    var item = cart.FirstOrDefault(x => x.producto.IdProducto == id);
                    if(item!=null)
                    {
                        cart.Remove(item);
                        await _localStorageService.SetItemAsync("cart", cart);
                        ShowItems.Invoke();
                    }
                
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<CarritoDTO>> ItemCart()
        {
            var cart = await _localStorageService.GetItemAsync<List<CarritoDTO>>("cart");
            if (cart == null) cart = new List<CarritoDTO>();

            return cart;
        }
    }
}
