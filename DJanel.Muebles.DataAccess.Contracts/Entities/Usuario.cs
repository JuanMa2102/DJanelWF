
namespace DJanel.Muebles.DataAccess.Contracts.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            DatosRol = new Rol();
        }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Pat { get; set; }
        public string Apellido_Mat { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }

        public Rol DatosRol { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Resultado { get; set; }

        public string NombreRol { get; set; }
        public string NombreCompleto { get; set; }
    }
}
