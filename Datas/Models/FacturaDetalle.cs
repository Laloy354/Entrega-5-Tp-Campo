using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class FacturaDetalle
    {
        [Key]
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        [ForeignKey("Factura")]
        public int FacturaId { get; set; }
        public Factura Factura { get; set; }
        [ForeignKey("Insumo")]
        public int InsumoId { get; set; }
        public Insumo Insumo { get; set; }
    }
}
