using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Insumo
    {
        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        [ForeignKey("Marca")]
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
    }
}
