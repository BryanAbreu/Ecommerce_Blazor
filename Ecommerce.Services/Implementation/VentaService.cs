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
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _Repository;
        private readonly IMapper _Mapper;

        public VentaService(IVentaRepository Repository, IMapper Mapper)
        {
            _Repository = Repository;
            _Mapper = Mapper;
        }

        public async Task<VentaDTO> Registre(VentaDTO model)
        {

            try
            {
                var dbModel = _Mapper.Map<Venta>(model);
                var sales = await _Repository.Registre(dbModel);

                if (sales.IdVenta == 0)
                    throw new TaskCanceledException("Error no generate sale service");
                else
                {
                    return _Mapper.Map<VentaDTO>(sales);
                
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
