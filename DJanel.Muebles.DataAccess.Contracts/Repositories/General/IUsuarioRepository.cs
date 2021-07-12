using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.Base;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Contracts.Repositories.General
{
    public interface IUsuarioRepository: IBaseRepository<Usuario>
    {
        Task<int> EsCuentaUnica(string Username);
        Task<Usuario> Login(string Account, string Password);
    }
}
