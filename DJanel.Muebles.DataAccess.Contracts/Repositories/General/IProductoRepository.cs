using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.Base;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Contracts.Repositories.General
{
    public interface IProductoRepository : IBaseRepository<Producto>
    {
        Task<int> ClaveExist(string ClaveBusqueda);
    }
}
