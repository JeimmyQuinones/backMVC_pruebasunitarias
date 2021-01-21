using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ProcesoViewModel
    {
        public int Idporceso { get; set; }
        [Required]
        public string nombre { get; set; }
        public int? procesopadre { get; set; }
        [Required]
        public int IdUsuario { get; set; }
    }
    public class ProcesoListViewModel : ProcesoViewModel
    {
        public string NombreUsuario { get; set; }
        public int Identificacion { get; set; }
        public string Nombreproyectopadre { get; set; }
    }
    public class ProcesoAddViewModel
    {
        public List<UsuarioViewModel> usuarios { get; set; }

        public List<ProcesoViewModel> procesos { get; set; }
    }
}