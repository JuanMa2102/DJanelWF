using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Contracts.Repositories.General
{
    public interface IProveedorRepository: IBaseRepository<Proveedor>
    {
        Task<IEnumerable<Proveedor>> Busqueda(string Busqueda, int IdProducto);
        Task<IEnumerable<Proveedor>> GetProveedorAsync(int IdProducto);
    }
}
