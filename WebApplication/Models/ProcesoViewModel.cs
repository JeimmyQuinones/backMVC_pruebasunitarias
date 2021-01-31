using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models
{
    public class ProcesoViewModel
    {
        public int Idporceso { get; set; }
     
        [Required]
        public string nombre { get; set; }
        public int? procesopadre { get; set; }
       
        public int IdUsuario { get; set; }
    }
    public class ProcesoListViewModel : ProcesoViewModel
    {
        public string NombreUsuario { get; set; }
        public int Identificacion { get; set; }
        public string Nombreproyectopadre { get; set; }
    }
    public class ProcesoAddViewModel: ProcesoViewModel
    {
        public IEnumerable<SelectListItem> usuarios { get; set; }

        public IEnumerable<SelectListItem> procesos { get; set; }
    }
}