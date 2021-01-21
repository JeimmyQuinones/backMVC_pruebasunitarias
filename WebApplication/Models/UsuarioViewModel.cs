using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "No se permiten caracteres especiales")]
        public string Nombre { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "No se permiten caracteres especiales")]
        public string Apellido { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Correo no valido")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "No se permiten caracteres especiales")]
        public int? Cedula { get; set; }
    }
}