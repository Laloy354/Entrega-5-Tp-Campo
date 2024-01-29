using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Afiliado
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cuit { get; set; }
        public DateTime FechaDeAgremiacion { get; set; }
        public int NumeroAgremiado { get; set; }
        [ForeignKey("TipoResponsableIVA")]
        public int TipoResponsableIVAId { get; set; }
        public TipoResponsableIVA TipoResponsableIVA { get; set; }
    }
}
