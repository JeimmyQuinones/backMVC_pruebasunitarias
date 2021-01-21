using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Proceso
    {
        [Key]
        [Required]
        public int Idporceso { get; set; }
        [Required]
        public string nombre { get; set; }
        public int? procesopadre { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        [ForeignKey("procesopadre")]
        public Proceso Procesos { get; set; }

    }
}
