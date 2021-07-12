using Dapper;
using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using DJanel.Muebles.DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Repositories.General
{
    public class RolRepository : Repository, IRolRepository
    {
        async public Task<IEnumerable<Rol>> GetComboRol()
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    var result = await conexion.QueryAsync<Rol>("[Usuario].[DJanel_Get_ComboRol]", param: dynamicParameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region Metodos Base
        public Task<Rol> AddAsync(Rol element, object IdUsuario)
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

        public Task<IEnumerable<Rol>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Rol> GetAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Rol> UpdateAsync(Rol element, object IdUsuario)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
