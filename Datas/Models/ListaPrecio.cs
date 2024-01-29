using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ListaPrecio
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TipoCondicionDeVenta")]
        public int TipoCondicionDeVentaId { get; set; }
        public TipoCondicionDeVenta TipoCondicionDeVenta { get; set; }
    }
}
