using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Transferencia
    {
        [Key]
        public int Id { get; set; }
        public float Monto { get; set; }
        public int MontoTransferencia { get; set; }
        [ForeignKey("Cobranza")]
        public int IdCobranza { get; set; }
        public Cobranza Cobranza { get; set; }
    }
}
