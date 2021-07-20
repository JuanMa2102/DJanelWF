using DJanel.Muebles.DataAccess.Contracts.DTOs;
using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Contracts.Repositories.General
{
    public interface IVentaRepository: IBaseRepository<Venta>
    {
        Task<string> GetFolioAsync();
        Task<Producto> GetProductoAsync(string clave);
        Task<IEnumerable<ReporteVenta>> GetReporteVentaAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<ReporteVenta>> GetVentaAsync(int IdVenta);
    }
}
