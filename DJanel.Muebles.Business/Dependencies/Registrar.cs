using DJanel.Muebles.CrossCutting.Services;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using DJanel.Muebles.DataAccess.Repositories.General;

namespace DJanel.Muebles.Business.Dependencies
{
    public static class Registrar
    {
        public static void RegisterDependencies()
        {
            ServiceLocator.Instance.Register<RolRepository, IRolRepository>();
            ServiceLocator.Instance.Register<UsuarioRepository, IUsuarioRepository>();
            ServiceLocator.Instance.Register<ProveedorRepository, IProveedorRepository>();
            ServiceLocator.Instance.Register<ProductosProveedorRepository, IProductosProveedorRepository>();
            ServiceLocator.Instance.Register<ProductoRepository, IProductoRepository>();
            ServiceLocator.Instance.Register<ProductoCompraRepository, IProductoCompraRepository>();
            ServiceLocator.Instance.Register<ClienteRepository, IClienteRepository>();
        }
    }
}
