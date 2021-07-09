using DJanel.Muebles.CrossCutting.Services;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General.Prueba;
using DJanel.Muebles.DataAccess.Repositories.General.Prueba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJanel.Muebles.Business.Dependencies
{
    public static class Registrar
    {
        public static void RegisterDependencies()
        {
            ServiceLocator.Instance.Register<ProductoRepository, IProductoRepository>();
        }
    }
}
