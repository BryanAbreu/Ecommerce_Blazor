using Ecommerce.Repository.Contracts;
using Ecommerce.Repository.DBcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Implementation
{
    public class GenericRepository<TModel> : IGenericReposistory<TModel> where TModel : class
    {
        private readonly DbEcommerceContext _dbContext;
        public GenericRepository(DbEcommerceContext dbContext)
        {
            _dbContext = dbContext;
               
        }

        public IQueryable<TModel> Get(Expression<Func<TModel, bool>>? filtro = null)
        {
            IQueryable<TModel> query = (filtro == null) ? _dbContext.Set<TModel>() : _dbContext.Set<TModel>().Where(filtro);

            return query;
        }

        public async Task<TModel> Create(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public async Task<bool> Delete(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Edit(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

       
    }
}
