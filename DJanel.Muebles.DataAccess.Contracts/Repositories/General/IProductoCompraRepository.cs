using DJanel.Muebles.DataAccess.Contracts.DTOs;
using DJanel.Muebles.DataAccess.Contracts.Repositories.Base;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Contracts.Repositories.General
{
    public interface IProductoCompraRepository : IBaseRepository<ProductoCompra>
    {
        Task<int> DeleteCompraAsync(object IdProductoCompra, object IdProducto, object IdUsuario);
    }
}
