using DJanel.Muebles.DataAccess.Contracts.DTOs;
using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Contracts.Repositories.General
{
    public interface IProductosProveedorRepository : IBaseRepository<ProductosProveedor>
    {
        Task<IEnumerable<Producto>> GetProductosAsync(object id);
    }
}
