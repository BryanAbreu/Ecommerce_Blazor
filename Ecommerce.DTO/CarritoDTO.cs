using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class CarritoDTO
    {
        public ProductoDTO? producto { get; set; }

        public int Cantidad { get; set; }
        public decimal? precio { get; set; }
        public decimal? total { get; set; }
    }
}
