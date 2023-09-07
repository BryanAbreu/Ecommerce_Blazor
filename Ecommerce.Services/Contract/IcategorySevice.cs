using Ecommerce.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Contract
{
    public interface IcategorySevice
    {
        Task<List<CategoriaDTO>> List( string search);
        Task<CategoriaDTO> GetIDCategory(int id);
        Task<CategoriaDTO> Create(CategoriaDTO model);
        Task<bool> Edit(CategoriaDTO model);
        Task<bool> Delete(int id);
    }
}
