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
    public class ProveedorRepository : Repository, IProveedorRepository
    {
        public async Task<Proveedor> AddAsync(Proveedor element, object IdUsuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Nombre_Empresa", element.Nombre_Empresa);
                    dynamicParameters.Add("@Nombre_Propietario", element.Nombre_Propietario);
                    dynamicParameters.Add("@Domicilio", element.Domicilio);
                    dynamicParameters.Add("@Telefono", element.Telefono);
                    dynamicParameters.Add("@Usuario", IdUsuario);
                    var result = await conexion.ExecuteScalarAsync<int>("[Proveedor].[DJanel_Create_Proveedor]", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                    element.Resultado = result;

                    return element;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeleteAsync(object id, object IdUsuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {

                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@IdProveedor", id);
                    dynamicParameters.Add("@Usuario", IdUsuario);
                    var result = await conexion.ExecuteScalarAsync<int>("[Proveedor].[DJanel_Delete_Proveedor]", param: dynamicParameters, commandType: CommandType.StoredProcedure);

                    return result;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<Proveedor>> GetAllAsync()
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    var result = await conexion.QueryAsync<Proveedor>("[Proveedor].[DJanel_GetAll_Proveedores]", param: dynamicParameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Proveedor> UpdateAsync(Proveedor element, object IdUsuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@IdProveedor", element.IdProveedor);
                    dynamicParameters.Add("@Nombre_Empresa", element.Nombre_Empresa);
                    dynamicParameters.Add("@Nombre_Propietario", element.Nombre_Propietario);
                    dynamicParameters.Add("@Domicilio", element.Domicilio);
                    dynamicParameters.Add("@Telefono", element.Telefono);
                    dynamicParameters.Add("@Usuario", IdUsuario);
                    var result = await conexion.ExecuteScalarAsync<int>("[Proveedor].[DJanel_Update_Proveedor]", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                    element.Resultado = result;

                    return element;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Proveedor> GetAsync(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExistAsync(object id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Proveedor>> Busqueda(string Busqueda, int IdProducto)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Busqueda", Busqueda);
                    dynamicParameters.Add("@IdProducto", IdProducto);
                    var result = await conexion.QueryAsync<Proveedor>("[Proveedor].[DJanel_Busqueda_ProveedoresXIdProducto]", param: dynamicParameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Proveedor>> GetProveedorAsync(int IdProducto)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@IdProducto", IdProducto);
                    var result = await conexion.QueryAsync<Proveedor>("[Proveedor].[DJanel_GetAll_ProveedoresXIdProducto]", param: dynamicParameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
