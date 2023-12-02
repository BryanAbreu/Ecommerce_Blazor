using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class TarjetaDTO
    {
        [Required(ErrorMessage ="ingrese titual")]
        public string? Titular { get; set; }

        [Required(ErrorMessage ="Ingresa Numero tarjeta")]
        public string? Numero { get; set; }
        [Required(ErrorMessage = "Ingresa vigencia")]
        public string? Viegencia { get; set; }
        [Required(ErrorMessage = "Ingresa CVV")]
        public string? cvv { get; set; }
    }
}
