using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Contracts.Repositories.General
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> Busqueda(string Busqueda);
    }
}
