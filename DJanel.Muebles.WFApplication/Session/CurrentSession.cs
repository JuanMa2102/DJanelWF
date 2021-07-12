using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJanel.Muebles.WFApplication.Session
{
    public static class CurrentSession
    {
        public static int IdUsuario { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido_Pat { get; set; }
        public static string Apellido_Mat { get; set; }
        public static string Domicilio { get; set; }
        public static string Telefono { get; set; }
        public static int IdRol { get; set; }
        public static string Username { get; set; }
        public static string NombreRol { get; set; }
        public static string NombreCompleto { get; set; }
    }
}
