using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Model;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace Ecommerce.Utility
{
    public class AutommaperProfile : Profile
    {
        public AutommaperProfile()
        {

            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, SesionDTO>().ReverseMap();



            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Producto, ProductoDTO>();
            CreateMap<ProductoDTO, Producto>().ForMember(X=>
            X.IdCategoriaNavigation,
            opt=> opt.Ignore());

            CreateMap<DetalleVenta, DetalleVentaDTO>().ReverseMap();
            CreateMap<Venta, VentaDTO>().ReverseMap();
        }
    }
}
