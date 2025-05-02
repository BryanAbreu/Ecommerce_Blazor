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
                
                // Set creation date if not provided
                if (!dbModel.FechaCreacion.HasValue)
                    dbModel.FechaCreacion = DateTime.Now;

                // Calculate total if not set
                if (!dbModel.Total.HasValue)
                {
                    dbModel.Total = dbModel.DetalleVenta.Sum(d => d.Total ?? 0);
                }

                var sales = await _Repository.Registre(dbModel);

                if (sales == null || sales.IdVenta == 0)
                    throw new TaskCanceledException("No se pudo generar la venta");

                return _Mapper.Map<VentaDTO>(sales);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la venta: " + ex.Message);
            }
        }
    }
}
