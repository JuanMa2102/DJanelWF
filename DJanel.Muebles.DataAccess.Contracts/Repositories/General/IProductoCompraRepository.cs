using DJanel.Muebles.DataAccess.Contracts.DTOs;
using DJanel.Muebles.DataAccess.Contracts.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Contracts.Repositories.General
{
    public interface IProductoCompraRepository : IBaseRepository<ProductoCompra>
    {
        Task<int> DeleteCompraAsync(object IdProductoCompra, object IdProducto, object IdUsuario);
        Task<IEnumerable<ReporteCompra>> GetReporteComprasAsync(DateTime startDate, DateTime endDate);
    }
}
