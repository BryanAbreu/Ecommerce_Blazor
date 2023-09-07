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
    public class CategoryService : IcategorySevice
    {
        private readonly IGenericReposistory<Categoria> _Repository;
        private readonly IMapper _Mapper;

        public CategoryService(IGenericReposistory<Categoria> Repository, IMapper Mapper)
        {
            _Repository = Repository;
            _Mapper = Mapper;
        }

        public async Task<CategoriaDTO> Create(CategoriaDTO model)
        {
            try
            {
                var dbModel = _Mapper.Map<Categoria>(model);
                var category = await _Repository.Create(dbModel);

                if (category.IdCategoria != 0)
                    return _Mapper.Map<CategoriaDTO>(category);
                else
                {
                    throw new TaskCanceledException("Error no create category service");
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
                var select = await _Repository.Get(x => x.IdCategoria == id).FirstOrDefaultAsync();
                if (select != null)
                {
                    var response = await _Repository.Delete(select);

                    if (!response)
                        throw new TaskCanceledException("NO delete category service");

                    return response;
                }
                else
                {
                    throw new TaskCanceledException("No Found category for delete service");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<bool> Edit(CategoriaDTO model)
        {
            try
            {
                var select = await _Repository.Get(x => x.IdCategoria == model.IdCategoria).FirstOrDefaultAsync();
                if (select != null)
                {
                    select.Nombre = model.Nombre;
                    
                    var response = await _Repository.Edit(select);

                    if (!response)
                        throw new TaskCanceledException("NO edit category service");

                    return response;

                }
                else { throw new TaskCanceledException("No Found category for edit service"); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<CategoriaDTO> GetIDCategory(int id)
        {
            try
            {
                var select = await _Repository.Get(x => x.IdCategoria == id).FirstOrDefaultAsync();
                if (select != null)
                    return _Mapper.Map<CategoriaDTO>(select);
                else
                { throw new TaskCanceledException("No found id category service"); }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<CategoriaDTO>> List( string search)
        {
            try
            {
                var select = _Repository.Get(x =>
                string.Concat(x.Nombre.ToLower()).Contains(search.ToLower())
                );

                List<CategoriaDTO> list = _Mapper.Map<List<CategoriaDTO>>(await select.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
