using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioProfileService.Api.Models.UsuarioProfile
{
    public class UsuarioProfileViewModel
    {
        // ID
        public int UsuarioId { get; set; }
        // NOMBRE
        public string Nombre { get; set; }
        // APELLIDO
        public string Apellido { get; set; }
        // CELULAR
        public string Celular { get; set; }
        // CORREO
        public string Correo { get; set; }
    }
}
