using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Contracts
{
    public interface ICartService
    {
        event Action ShowItems;

        int CartAmount();
        Task AddToCart(CarritoDTO model);
        Task DelteToCart(int id);
        //articulos del carrito
        Task<List<CarritoDTO>>ItemCart ();
        Task Clearcart ();



    }
}
