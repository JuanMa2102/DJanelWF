using System;

namespace DJanel.Muebles.DataAccess.Contracts.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Pat { get; set; }
        public string Apellido_Mat { get; set; }
        public DateTime Fecha_Nac { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
    }
}
