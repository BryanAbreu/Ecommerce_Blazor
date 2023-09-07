using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "ingrese nombre")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "ingrese Descripcion")]
        public string? Descripcion { get; set; }

        public int? IdCategoria { get; set; }

        [Required(ErrorMessage = "ingrese Precio")]
        public decimal? Precio { get; set; }

        [Required(ErrorMessage = "ingrese Precio Oferta")]
        public decimal? PrecioOferta { get; set; }

        [Required(ErrorMessage = "ingrese Cantidad")]
        public int? Cantidad { get; set; }

        [Required(ErrorMessage = "ingrese Imagen")]
        public string? Imagen { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public virtual CategoriaDTO? IdCategoriaNavigation { get; set; }

    }
}
