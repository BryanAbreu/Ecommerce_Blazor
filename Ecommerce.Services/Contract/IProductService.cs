using Ecommerce.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Contract
{
    public interface IProductService
    {
        Task<List<ProductoDTO>> List(string search);
        Task<List<ProductoDTO>> catalog( string category,string search);
        Task<ProductoDTO> GetProductID(int id);
        Task<ProductoDTO> Create(ProductoDTO model);
        Task<bool> Edit(ProductoDTO model);
        Task<bool> Delete(int id);
    }
}
