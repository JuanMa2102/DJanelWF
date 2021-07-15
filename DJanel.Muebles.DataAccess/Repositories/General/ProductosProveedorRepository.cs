using Dapper;
using DJanel.Muebles.DataAccess.Contracts.DTOs;
using DJanel.Muebles.DataAccess.Contracts.Entities;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using DJanel.Muebles.DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DJanel.Muebles.DataAccess.Repositories.General
{
    public class ProductosProveedorRepository : Repository, IProductosProveedorRepository
    {
        public async Task<ProductosProveedor> AddAsync(ProductosProveedor element, object IdUsuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    using (var tran = conexion.BeginTransaction())
                    {
                        try
                        {
                            var dynamicParameters = new DynamicParameters();
                            dynamicParameters.Add("@Nombre_Empresa", element.DatosProveedor.Nombre_Empresa);
                            dynamicParameters.Add("@Nombre_Propietario", element.DatosProveedor.Nombre_Propietario);
                            dynamicParameters.Add("@Domicilio", element.DatosProveedor.Domicilio);
                            dynamicParameters.Add("@Telefono", element.DatosProveedor.Telefono);
                            dynamicParameters.Add("@Usuario", IdUsuario);
                            var id = await conexion.ExecuteScalarAsync<int>("[Proveedor].[DJanel_Create_Proveedor]", param: dynamicParameters, commandType: CommandType.StoredProcedure, transaction: tran);

                            foreach (var item in element.ListaProducto)
                            {
                                var dynamicParametersDetail = new DynamicParameters();
                                dynamicParametersDetail.Add("@IdProveedor", id);
                                dynamicParametersDetail.Add("@IdProducto", item.IdProducto);
                                await conexion.ExecuteScalarAsync<int>("[Proveedor].[DJanel_Create_ProductosProveedor]", param: dynamicParametersDetail, commandType: CommandType.StoredProcedure, transaction: tran);
                            }

                            element.Resultado = 1;
                            tran.Commit();
                            return element;
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductosProveedor> UpdateAsync(ProductosProveedor element, object IdUsuario)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    using (var tran = conexion.BeginTransaction())
                    {
                        try
                        {
                            var dynamicParameters = new DynamicParameters();
                            dynamicParameters.Add("@IdProveedor", element.DatosProveedor.IdProveedor);
                            dynamicParameters.Add("@Nombre_Empresa", element.DatosProveedor.Nombre_Empresa);
                            dynamicParameters.Add("@Nombre_Propietario", element.DatosProveedor.Nombre_Propietario);
                            dynamicParameters.Add("@Domicilio", element.DatosProveedor.Domicilio);
                            dynamicParameters.Add("@Telefono", element.DatosProveedor.Telefono);
                            dynamicParameters.Add("@Usuario", IdUsuario);
                            await conexion.ExecuteScalarAsync<int>("[Proveedor].[DJanel_Update_Proveedor]", param: dynamicParameters, commandType: CommandType.StoredProcedure, transaction: tran);

                            var dynamicParametersDelete = new DynamicParameters();
                            dynamicParametersDelete.Add("@IdProveedor", element.DatosProveedor.IdProveedor);
                            await conexion.ExecuteScalarAsync<int>("[Proveedor].[DJanel_Delete_ProductosProveedor]", param: dynamicParametersDelete, commandType: CommandType.StoredProcedure, transaction: tran);

                            foreach (var item in element.ListaProducto)
                            {
                                var dynamicParametersDetail = new DynamicParameters();
                                dynamicParametersDetail.Add("@IdProveedor", element.DatosProveedor.IdProveedor);
                                dynamicParametersDetail.Add("@IdProducto", item.IdProducto);
                                await conexion.ExecuteScalarAsync<int>("[Proveedor].[DJanel_Create_ProductosProveedor]", param: dynamicParametersDetail, commandType: CommandType.StoredProcedure, transaction: tran);
                            }

                            element.Resultado = 1;
                            tran.Commit();
                            return element;
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<ProductosProveedor> GetAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Producto>> GetProductosAsync(object id)
        {
            try
            {
                using (IDbConnection conexion = new SqlConnection(WebConnectionString))
                {
                    conexion.Open();
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@IdProveedor", id);
                    var result = await conexion.QueryAsync<Producto>("[Proveedor].[DJanel_GetAll_ProductosProveedor]", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Task<bool> ExistAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductosProveedor>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<int> DeleteAsync(object id, object IdUsuario)
        {
            throw new NotImplementedException();
        }

    }
}
