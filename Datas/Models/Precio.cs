using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Precio
    {
        [Key]
        public int Id { get; set; }
        public float Monto { get; set; }
        [ForeignKey("Insumo")]
        public int InsumoId { get; set; }
        public Insumo Insumo { get; set; }
        [ForeignKey("ListaPrecio")]
        public int ListaPrecioId { get; set; }
        public ListaPrecio ListaPrecio { get; set; }

    }
}
