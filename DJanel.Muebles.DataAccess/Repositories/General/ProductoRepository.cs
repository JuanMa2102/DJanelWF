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
    public class ProductoRepository : Repository, IProductoRepository
    {
        public async Task<Producto> AddAsync(Producto element, object IdUsuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Nombre", element.Nombre);
                    dynamicParameters.Add("@Descrpcion", element.Descripcion);
                    dynamicParameters.Add("@Precio", element.Precio);
                    dynamicParameters.Add("@Stock", element.Stock);
                    dynamicParameters.Add("@Marca", element.Marca);
                    dynamicParameters.Add("@Modelo", element.Modelo);
                    dynamicParameters.Add("@ClaveBusqueda", element.ClaveBusqueda);
                    dynamicParameters.Add("@Usuario", IdUsuario);
                    var result = await conexion.ExecuteScalarAsync<int>("[Producto].[DJanel_Create_Producto]", param: dynamicParameters, commandType: CommandType.StoredProcedure);
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
                    dynamicParameters.Add("@IdProducto", id);
                    dynamicParameters.Add("@Usuario", IdUsuario);
                    var result = await conexion.ExecuteScalarAsync<int>("[Producto].[DJanel_Delete_Producto]", param: dynamicParameters, commandType: CommandType.StoredProcedure);

                    return result;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {

            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    var result = await conexion.QueryAsync<Producto>("[Producto].[DJanel_GetAll_Productos]", param: dynamicParameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Producto> UpdateAsync(Producto element, object IdUsuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@IdProducto", element.IdProducto);
                    dynamicParameters.Add("@Nombre", element.Nombre);
                    dynamicParameters.Add("@Descrpcion", element.Descripcion);
                    dynamicParameters.Add("@Precio", element.Precio);
                    dynamicParameters.Add("@Stock", element.Stock);
                    dynamicParameters.Add("@Marca", element.Marca);
                    dynamicParameters.Add("@Modelo", element.Modelo);
                    dynamicParameters.Add("@ClaveBusqueda", element.ClaveBusqueda);
                    dynamicParameters.Add("@Usuario", IdUsuario);
                    var result = await conexion.ExecuteScalarAsync<int>("[Producto].[DJanel_Update_Producto]", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                    element.Resultado = result;

                    return element;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> ClaveExist(string ClaveBusqueda)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@ClaveBusqueda", ClaveBusqueda);
                    var dr = await conexion.ExecuteScalarAsync<int>("[Producto].[DJanel_ValidarClaveBusqueda_Producto]", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                    return dr;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Producto> GetAsync(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExistAsync(object id)
        {
            throw new System.NotImplementedException();
        }

        
    }
}
