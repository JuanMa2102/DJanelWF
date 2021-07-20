using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Contracts.Repositories.General
{
    public interface IProductoRepository : IBaseRepository<Producto>
    {
        Task<int> ClaveExist(string Busqueda);
        Task<IEnumerable<Producto>> Busqueda(string Busqueda);
        Task<IEnumerable<Producto>> GetProductoReporte();
        Task<int> GetStockAsync(int IdProducto);
    }
}
