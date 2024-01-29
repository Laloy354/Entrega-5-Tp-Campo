using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Cobranza
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public float MontoTotal { get; set; }
        [ForeignKey("Afiliado")]
        public int AfiliadoId { get; set; }
        public Afiliado Afiliado { get; set; }
        [ForeignKey("Factura")]
        public int FacturaId { get; set; }
        public Factura Factura { get; set; }
    }
}
