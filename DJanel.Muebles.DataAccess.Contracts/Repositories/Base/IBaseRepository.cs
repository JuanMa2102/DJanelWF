using System.Collections.Generic;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Contracts.Repositories.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<bool> ExistAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(object id);
        Task<int> DeleteAsync(object id, object IdUsuario);
        Task<T> UpdateAsync(T element, object IdUsuario);
        Task<T> AddAsync(T element, object IdUsuario);
    }
}
