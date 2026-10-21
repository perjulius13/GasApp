using System;
using System.Collections.Generic;
using System.Text;

namespace GasApp.Models
{
    internal class UsuarioClass
    {
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? Contra { get; set; }

        public string? Nombre { get; set; }

        public string? Paterno { get; set; }

        public string? Materno { get; set; }

        public string? Genero { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }

        public DateTime Fechaalta { get; set; }

        public int Usuarioreg { get; set; }

        public int TipoUser { get; set; }

        public bool Habilitado { get; set; }
    }
}
