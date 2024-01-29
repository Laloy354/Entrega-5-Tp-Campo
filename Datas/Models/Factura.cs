using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaEmision { get; set; }
        public float ImporteTotal { get; set; }
        public int NumeroComprobante { get; set; }
        public float SubTotal { get; set; }
        [ForeignKey("TipoMedioPago")]
        public int TipoMedioPagoId { get; set; }
        public TipoMedioPago TipoMedioPago { get; set; }
        [ForeignKey("Afiliado")]
        public int AfiliadoId { get; set; }
        public Afiliado Afiliado { get; set; }
    }
}
