
namespace DJanel.Muebles.DataAccess.Contracts.Entities
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descrpcion { get; set; }
        public int Stock { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string ClaveBusqueda { get; set; }
    }
}
