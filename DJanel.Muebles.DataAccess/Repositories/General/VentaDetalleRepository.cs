using Dapper;
using DJanel.Muebles.DataAccess.Contracts.DTOs;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using DJanel.Muebles.DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Repositories.General
{
    public class VentaDetalleRepository : Repository, IVentaDetalleRepository
    {
        public Task<VentaDetalle> AddAsync(VentaDetalle element, object IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(object id, object IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VentaDetalle>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<VentaDetalle> GetAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<VentaDetalle> UpdateAsync(VentaDetalle element, object IdUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
