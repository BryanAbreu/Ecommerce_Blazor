using Ecommerce.Model;
using Ecommerce.Repository.Contracts;
using Ecommerce.Repository.DBcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Implementation
{
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {
        private readonly DbEcommerceContext _dbContext;
        public VentaRepository(DbEcommerceContext dbContext): base(dbContext) 
        {
            _dbContext = dbContext;

        }

        public async Task<Venta> Registre(Venta model)
        {
            Venta ventagenerada  = new Venta();

            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetalleVenta dv in model.DetalleVenta)
                    {
                        Producto producto = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

                        producto.Cantidad = producto.Cantidad - dv.Cantidad;
                        _dbContext.Productos.Update(producto);
                    }
                    await _dbContext.SaveChangesAsync();

                    await _dbContext.Venta.AddAsync(model);
                    ventagenerada = model;

                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            return ventagenerada;
        }
    }
}
