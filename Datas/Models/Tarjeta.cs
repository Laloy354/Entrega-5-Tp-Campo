using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Tarjeta
    {
        [Key]
        public int Id { get; set; }
        public float Monto { get; set; }
        public string Numero { get; set; }
        [ForeignKey("TipoTarjeta")]
        public int TipoTarjetaId { get; set; }
        public TipoTarjeta TipoTarjeta { get; set; }
        [ForeignKey("Cobranza")]
        public int CobranzaId { get; set; }
        public Cobranza Cobranza { get; set; }

    }
}
