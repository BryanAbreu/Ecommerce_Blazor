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
    public class DashboardService : IDashboardService
    {

        private readonly IGenericReposistory<Usuario> _UsuarioRepository;
        private readonly IGenericReposistory<Producto> _ProductoRepository;
        private readonly IVentaRepository _VentaRepository;
        private readonly IMapper _Mapper;

        public DashboardService(IGenericReposistory<Usuario> UsuarioRepository, IGenericReposistory<Producto> ProductoRepository,
            IVentaRepository VentaRepository,IMapper Mapper)
        {
            _UsuarioRepository = UsuarioRepository;
            _ProductoRepository = ProductoRepository;
            _Mapper = Mapper;
        }
        //funciones----------------
        string? income() 
        {
            decimal? select = Convert.ToDecimal(_VentaRepository.Get().Sum(x => x.Total));
            
            return Convert.ToString(select);
        }
        int TotalSales()
        {
            int select = Convert.ToInt32(_VentaRepository.Get().Count());

            return select;
        }
        int TotalClient()
        {
            int select = Convert.ToInt32 (_UsuarioRepository.Get(x=> x.Rol== "Cliente").Count());

            return select; 
        }

        int TotalProduct()
        {
            int select = Convert.ToInt32(_ProductoRepository.Get().Count());
            return select;
        }
        //---------------------

        public DashboardDTO Resume()
        {
            DashboardDTO dto = new DashboardDTO()
            {
                TotalVentas = TotalSales(),
                TotalIngresos = income(),
                TotalCliente = TotalClient(),
                TotalProductos = TotalProduct()
            };
                return dto;
        }
    }
}
