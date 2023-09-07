using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Contracts
{
    public interface IVentaRepository : IGenericReposistory<Venta>
    {
        Task<Venta>Registre(Venta model);
    }
}
