using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Ecommerce.Model;
using Ecommerce.DTO;
using Ecommerce.Repository.Contracts;
using Ecommerce.Services.Contract;
using AutoMapper;
using AutoMapper.Execution;


namespace Ecommerce.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IGenericReposistory<Producto> _Repository;
        private readonly IMapper _Mapper;

        public ProductService(IGenericReposistory<Producto> Repository, IMapper Mapper)
        {
            _Repository = Repository;
            _Mapper = Mapper;
        }

        public async Task<List<ProductoDTO>> catalog(string category, string search)
        {
            try
            {
                var select = _Repository.Get(x =>
                x.Nombre.ToLower().Contains(search.ToLower()) &&
                x.IdCategoriaNavigation.Nombre.ToLower().Contains(category.ToLower())
                );

                List<ProductoDTO> list = _Mapper.Map<List<ProductoDTO>>(await select.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ProductoDTO> Create(ProductoDTO model)
        {
            try
            {
                var dbModel = _Mapper.Map<Producto>(model);
                var product = await _Repository.Create(dbModel);

                if (product.IdProducto != 0)
                    return _Mapper.Map<ProductoDTO>(product);
                else
                {
                    throw new TaskCanceledException("Error no create product service");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var select = await _Repository.Get(x => x.IdProducto == id).FirstOrDefaultAsync();
                if (select != null)
                {
                    var response = await _Repository.Delete(select);

                    if (!response)
                        throw new  TaskCanceledException("NO delete product service");

                    return response;
                }
                else
                {
                    throw new TaskCanceledException("No Found product for delete service");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Edit(ProductoDTO model)
        {
            try
            {
                //pendiente revisar
               // var select = await _Repository.Get(x => x.IdProducto == model.IdProducto && x.IdCategoria == model.IdCategoria).FirstOrDefaultAsync();
                var select = await _Repository.Get(x => x.IdProducto == model.IdProducto).FirstOrDefaultAsync();
                if (select != null)
                {
                    select.Nombre = model.Nombre;
                    select.Precio = model.Precio;
                    select.PrecioOferta = model.PrecioOferta;
                    select.Cantidad = model.Cantidad;
                    select.Descripcion = model.Descripcion;
                    select.IdCategoria = model.IdCategoria;
                    select.Imagen = model.Imagen;

                    var response = await _Repository.Edit(select);

                    if (!response)
                        throw new TaskCanceledException("NO edit product service");

                    return response;

                }
                else { throw new TaskCanceledException("No Found product for edit service"); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ProductoDTO> GetProductID(int id)
        {
            try
            {//probar
                var select = await _Repository.Get(x => x.IdProducto == id).Include(c=> c.IdCategoriaNavigation).FirstOrDefaultAsync();

                if (select != null)
                    return _Mapper.Map<ProductoDTO>(select);
                else
                { throw new TaskCanceledException("No found id product service"); }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ProductoDTO>> List(string search)
        {
            try
            {
                var select = _Repository.Get(x =>
                x.Nombre.ToLower().Contains(search.ToLower())
                );

                select = select.Include(x => x.IdCategoriaNavigation);

                List<ProductoDTO> list = _Mapper.Map<List<ProductoDTO>>(await select.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
